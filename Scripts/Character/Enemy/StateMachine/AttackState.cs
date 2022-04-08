using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    public override void OnStateStart()
    {
        base.OnStateStart();
        //����ʱ��ֹͣ�ƶ�
        GetComponent<NavMeshAgent>().destination = transform.position;
    }
    public override void OnStateUpdate()
    {
        //ȱ��targetʱ�л�������State
        if (enemycontrol.target == null)
        {
            FindState(StateType.Idle);
            FindState(StateType.Patrol);
        }
        //ToChase
        if (Vector3.Distance(transform.position, enemycontrol.target.position)
            > characterManager.attack.attackdistance
            && Vector3.Distance(transform.position, enemycontrol.target.position) <= enemycontrol.chaseradius)
            FindState(StateType.Chase);
        //ToIdle
        else if (Vector3.Distance(transform.position, enemycontrol.target.position) > enemycontrol.chaseradius)
        {
            FindState(StateType.Idle);
            FindState(StateType.Patrol);
        }

        if (CheckTransition())
        {
            OnStateExit();
            return;
        }
        transform.LookAt(enemycontrol.target);
        enemycontrol.isattack = true;


    }
    //ʹ�ü���
    public void EnemySkill()
    {
        if (GetComponent<Skill>().CanUseSkill())
            GetComponent<Skill>().UseSkill();
    }
    public override void OnStateExit()
    {
        enemycontrol.isattack = false;
        base.OnStateExit();
        
    }
}
