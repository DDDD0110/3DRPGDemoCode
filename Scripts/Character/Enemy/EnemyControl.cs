using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour,IEndGame
{
    private NavMeshAgent agent;
    private Animator anim;
    private HealthBar healthBar;
    private bool isdead;

    [HideInInspector]
    public CharacterManager enemystate;

    public BaseState startstate;
    public float lookradius;
    public float chaseradius;
    public LayerMask playerMask;
    public float chasespeed;
    public float patrolspeed;
    public bool isattack;
    public bool iscrit;
    public string EnemyName;

    //[HideInInspector]
    public BaseState currentstate;
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public Vector3 startposition;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        healthBar = GetComponent<HealthBar>();
        enemystate = GetComponent<CharacterManager>();
        currentstate = startstate;
        startposition = transform.position;

    }
    private void OnEnable()
    {
        currentstate.OnStateStart();
        UpdateHealthBar();
        GameManager.Instance.AddObserver(this);
        enemystate.UpdateHealthBar += UpdateHealthBar;
    }
    private void OnDisable()
    {
        if (GameManager.Isinitialized)
            GameManager.Instance.RemoveObserver(this);
    }

    private void Update()
    {

        currentstate.OnStateUpdate();
        AnimControl();
        CheckHealth();
    }
    public void UpdateHealthBar()
    {
        healthBar.UpdateHealthBar(enemystate.MaxHealth, enemystate.CurrentHealth);
    }
    //在可视范围内是否有PALYERs
    public bool CheckTarget()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, lookradius, playerMask);
        foreach (var coll in colls)
        {
            if (transform.IsFaceToTarget(coll.transform) && coll.CompareTag("Player"))
            {
                target = coll.transform;
                return true;
            }
        }
        return false;
    }
    public void MoveTo(Vector3 des)
    {
        if (currentstate.statetype == StateType.Chase)
            agent.speed = chasespeed;
        else
            agent.speed = patrolspeed;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(des, out hit, 1f, 1))
            agent.destination = hit.position;
        else
            agent.destination = transform.position;
    }
    public void Hit()
    {
        if (isdead)
            return;
        if (target == null)
            return;
        target.GetComponent<CharacterManager>().GetHit(enemystate,false);
    }
    public void SkillHit()
    {
        if (target == null)
            return;
        target.GetComponent<CharacterManager>().GetHit(enemystate, true);
    }
    void AnimControl()
    {
        if (currentstate.statetype == StateType.Chase)
            anim.SetBool("isrun", true);
        else
            anim.SetBool("isrun", false);
        anim.SetFloat("speed", agent.velocity.sqrMagnitude);
        anim.SetBool("isattack", isattack);
        anim.SetBool("isdead", isdead);

    }
    //如果HP归零则进入DEADSTATE
    void CheckHealth()
    {
        if (enemystate.CurrentHealth <= 0)
        {
            currentstate.nextstate= GetComponent<DeadState>();
            currentstate.OnStateExit();
        }
    }
    public void EnemyDead()
    {
        if (isdead)
            return;
        isdead = true;
        anim.SetBool("isattack", false);
        healthBar.DestroyBar();
        TaskManager.Instance.UpdateHuntTaskProgress(EnemyName);
        GameManager.Instance.EnemyDead(enemystate.characterstate.enemyexp);
    }

    //PLAYER死亡后调用
    public void EndNotify()
    {
        agent.isStopped = true;
        currentstate.nextstate = GetComponent<VictoryState>();
        currentstate.OnStateExit();
        anim.SetBool("isvictory",true);
    }
}
