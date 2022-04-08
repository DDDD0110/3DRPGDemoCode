using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public override void OnStateStart()
    {
        base.OnStateStart();
    }

    public override void OnStateUpdate()
    {
        //ToAttack
        if (enemycontrol.target != null
            && Vector3.Distance(transform.position, enemycontrol.target.position)
            <= characterManager.attack.attackdistance)
            FindState(StateType.Attack);
        //ToIdle
        else if (enemycontrol.target == null
                || Vector3.Distance(transform.position, enemycontrol.target.position)
                 > enemycontrol.chaseradius)
        {
            FindState(StateType.Idle);
            FindState(StateType.Patrol);
        }

            if (CheckTransition())
            {
                OnStateExit();
                return;
            }
        //±¾×´Ì¬ÐÐÎª
        if (enemycontrol.target != null)
            enemycontrol.MoveTo(enemycontrol.target.position);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
