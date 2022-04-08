using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    public override void OnStateStart()
    {
        base.OnStateStart();
        if (enemycontrol != null
            && Vector3.Distance(transform.position, enemycontrol.startposition) > 2f)
            enemycontrol.MoveTo(enemycontrol.startposition);
    }
    public override void OnStateUpdate()
    {
        //ToChase
        if (enemycontrol.CheckTarget())
        {
            FindState(StateType.Chase);
        }

        if (CheckTransition())
        {
            OnStateExit();
            return;
        }
        //本状态行为
    }
    public override void OnStateExit()
    {
        //退出状态的动作
        base.OnStateExit();
    }
}
