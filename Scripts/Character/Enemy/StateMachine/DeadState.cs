using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : BaseState
{
    public override void OnStateStart()
    {
        base.OnStateStart();
        enemycontrol.EnemyDead();
        Invoke("DestroyEnemy", 2f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
