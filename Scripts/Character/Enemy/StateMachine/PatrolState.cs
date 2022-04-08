using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : BaseState
{
    public float patrolRadius;

    Vector3 patroldestination;
    public override void OnStateStart()
    {
        base.OnStateStart();
        patroldestination = transform.position;
    }
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        if (enemycontrol.CheckTarget())
        {
            FindState(StateType.Chase);
        }

        if (CheckTransition())
        {
            OnStateExit();
            return;
        }

        //巡逻
        if ((transform.position-patroldestination).sqrMagnitude<1f)//到达当前目标
        {
            FindRandomDestination();//随机寻找下一个巡逻点
        }
        enemycontrol.MoveTo(patroldestination);

    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    void FindRandomDestination()
    {
        float x = Random.Range(-patrolRadius, patrolRadius);
        float z = Random.Range(-patrolRadius, patrolRadius);
        patroldestination = new Vector3(enemycontrol.startposition.x + x, enemycontrol.startposition.y, enemycontrol.startposition.z + z);   
    }
}
