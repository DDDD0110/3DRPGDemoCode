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

        //Ѳ��
        if ((transform.position-patroldestination).sqrMagnitude<1f)//���ﵱǰĿ��
        {
            FindRandomDestination();//���Ѱ����һ��Ѳ�ߵ�
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
