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
        //��״̬��Ϊ
    }
    public override void OnStateExit()
    {
        //�˳�״̬�Ķ���
        base.OnStateExit();
    }
}
