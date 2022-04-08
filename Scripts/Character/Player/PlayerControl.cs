using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Cinemachine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    private NavMeshAgent agent;
    private InputControls playerinput;
    private Animator anim;
    private CharacterManager playerstate;
    private PlayerHealthBar healthbar;


    public CinemachineFreeLook cam;
    public float speed;
    private float cammovespeedX = 2.5f;
    public bool movebymouse = false;
    public bool iscombo;
    public LayerMask enemylayer;
    public float attackradius;
    public PlayerAttack weapon;
    public Transform camlookat;

    public Transform lhand;
    public Transform rhand;

    Vector2 move;
    float camaxisX;
    float camaxisY;
    bool _movebymouse=false;
    bool isdead;
    bool isstart = false;
    public bool isattack;
    public bool continueattack;
    public int index;
    

    private void Awake()
    {
        playerinput = new InputControls();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        playerstate = GetComponent<CharacterManager>();
        healthbar = FindObjectOfType<PlayerHealthBar>();
        playerstate.UpdateHealthBar += UpdateHealthBar;
        playerstate.UpdateExpbar += UpdateExpbar;
        
        playerinput.Player.move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerinput.Player.move.canceled += ctx => move = Vector2.zero;
        playerinput.CAM.cam.performed += ctx => camaxisX = ctx.ReadValue<float>();
        playerinput.CAM.cam.canceled += ctx => camaxisX = 0f;
        playerinput.CAM.camY.performed += ctx => camaxisY = ctx.ReadValue<float>();
        playerinput.CAM.camY.canceled += ctx => camaxisY = 0f;
        playerinput.Player.attack.performed += Attack;
        playerinput.Player0.attack.performed += Attack;
        
    }
    private void OnEnable()
    {
        GameManager.Instance.PlayerRegister(playerstate, this);
        //设定camera跟随
        cam = FindObjectOfType<CinemachineFreeLook>();
        cam.LookAt = camlookat;
        cam.Follow = camlookat;
        playerinput.CAM.Enable();
        playerinput.Player.Enable();
        isstart = true;
        weapon = FindObjectOfType<PlayerAttack>();
    }
    private void OnDisable()
    {
        playerinput.CAM.Disable();
        playerinput.Player.Disable();
        playerinput.Player0.Disable();
        isstart = false;
    }
    public void UpdateHealthBar()
    {
        healthbar.UpdateHealthBar(playerstate.MaxHealth, playerstate.CurrentHealth);   
    }
    public void UpdateExpbar()
    {
        healthbar.UpdateExpbar(playerstate.LevelUpExp, playerstate.Exp);
    }


    private void FixedUpdate()
    {
        CameraControl();
    }
    private void Update()
    {
        if (isdead||!isstart)
            return;
        index = playerstate.attack.comboindex;
        //切换控制方式
        if (movebymouse != _movebymouse)
        {
            if (movebymouse)
            {
                MouseManager.Instance.OnClickMouse += MoveTo;
                playerinput.Player.Disable();
                playerinput.Player0.Enable();
            }
            else
            {
                MouseManager.Instance.OnClickMouse -= MoveTo;
                playerinput.Player.Enable();
                playerinput.Player0.Disable();
            }
            _movebymouse = movebymouse;
        }
        Move();
        
        AnimControl();
        CheckAttackState();
        if (playerstate.CurrentHealth <= 0)
            PlayerDead();

    }

    private void AnimControl()
    {
        anim.SetFloat("speed", agent.velocity.sqrMagnitude);
        anim.SetBool("isattack", isattack);
        anim.SetInteger("comboindex", playerstate.attack.comboindex);
    }

    //方案1移动
    void Move()
    {
        if (isattack)
            return;
        if (_movebymouse)
            return;
        if (move == Vector2.zero)
        {
            agent.isStopped = true;
            agent.isStopped = false;
            return;
        }
        else
        {
            move.Normalize();
            Vector3 forward = transform.position - cam.transform.position;
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = new Vector3(-forward.z, 0f, forward.x);
            Vector3 des = forward * move.y + -right * move.x;
            des = des * speed + transform.position;
            MoveTo(des);
        }
        
    }
    //方案2移动
    void MoveTo(Vector3 des)
    {
        if (isattack)
            return;
        agent.isStopped = false;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(des, out hit, 1f, 1))
            agent.destination = hit.position;
        else
            agent.destination = transform.position;
    }


    #region Attack and Combo
    void Attack(InputAction.CallbackContext callback)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        agent.isStopped = true;
        Collider[] colls = Physics.OverlapSphere(transform.position, attackradius, enemylayer);
        foreach (var coll in colls)
        {
            if (coll.CompareTag("Enemy"))
                transform.forward = coll.transform.position - transform.position;
        }
        weapon.OpenCol();
        if (!isattack)
        {
            isattack = true;
            anim.SetBool("isattack",isattack);
        }
        if(continueattack)
        {
            isattack = true;
            if (playerstate.attack.comboindex >= playerstate.attack.BaseAttack.Count-1)
                playerstate.attack.comboindex = 0;
            else
                playerstate.attack.comboindex++;
            continueattack = false;
        }
    }

    public void attackEnd()
    {
        isattack = false;
        weapon.CloseCol();

    }

    //继续攻击的输入窗口
    public void OpenAttackInput()
    {
        continueattack = true;
        Invoke("CloseAttackInput", 0.14f);
    }

    void CloseAttackInput()
    {
        continueattack = false;
        if (!isattack)
            playerstate.attack.comboindex = 0;
    }
    void CheckAttackState()
    {
        if(!isattack&&!continueattack)
            playerstate.attack.comboindex = 0;
    }

    public void Hit(Transform target)
    {
        if (isdead)
            return;
        target.GetComponent<CharacterManager>().GetHit(playerstate,false);
    }

    #endregion

    void PlayerDead()
    {
        isdead = true;
        agent.isStopped = true;
        anim.SetBool("isdead", isdead);
        anim.SetBool("isattack", false);
        GameManager.Instance.GameOver();
    }

    void CameraControl()
    {
        if (camaxisX > 0)
            cam.m_XAxis.Value += cammovespeedX;
        else if (camaxisX < 0)
            cam.m_XAxis.Value -= cammovespeedX;
        if (camaxisY > 0)
            cam.m_YAxis.Value = Mathf.Min(1f, cam.m_YAxis.Value + 0.025f);
        else if (camaxisY < 0)
            cam.m_YAxis.Value = Mathf.Max(0.5f, cam.m_YAxis.Value - 0.025f);
    }

    public void ChangeWeapon(GameObject lweapon, GameObject rweapon, AnimatorOverrideController Wanim)
    {
        for (int i = 0; i < lhand.childCount; i++)
            Destroy(lhand.GetChild(i).gameObject);
        for (int i = 0; i < rhand.childCount; i++)
            Destroy(rhand.GetChild(i).gameObject);
        if (lweapon != null)
            Instantiate(lweapon, lhand);
        if (rweapon != null)
            Instantiate(rweapon, rhand);
        anim.runtimeAnimatorController = Wanim;
        weapon = FindObjectOfType<PlayerAttack>();

    }


}
