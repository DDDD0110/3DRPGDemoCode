using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : BaseState
{
    public override void OnStateStart()
    {
        base.OnStateStart();
        //攻击时，停止移动
        GetComponent<NavMeshAgent>().destination = transform.position;
    }
    public override void OnStateUpdate()
    {
        //缺少target时切换至其他State
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
    //使用技能
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
