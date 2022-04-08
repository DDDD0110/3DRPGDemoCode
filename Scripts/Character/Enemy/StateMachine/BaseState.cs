using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    protected EnemyControl enemycontrol;
    protected CharacterManager characterManager;

    public List<StateTransition> transition = new List<StateTransition>();
    public StateType statetype;

    [HideInInspector]
    public BaseState nextstate;

    protected virtual void Awake()
    {
        enemycontrol = GetComponent<EnemyControl>();
        characterManager = GetComponent<CharacterManager>();
    }
    public virtual void OnStateStart()
    {
        for (int i = 0; i < transition.Count; i++)
            transition[i].cantransition = false;
    }
    public virtual void OnStateUpdate()
    { }
    public virtual void OnStateExit()
    {
        enemycontrol.currentstate = nextstate;
        nextstate.OnStateStart();
    }

    //确认下一个状态
    protected bool CheckTransition()
    {
        for (int i = 0; i < transition.Count; i++)
            if (transition[i].cantransition == true)
            {
                nextstate = transition[i].To;
                return true;
            }
        return false;

    }
    //检查是否能切换至指定状态
    protected void FindState(StateType state)
    {
        for (int i = 0; i < transition.Count; i++)
        {
            if (transition[i].To.statetype == state)
                transition[i].cantransition = true;
        }
    }
}

[System.Serializable]
public class StateTransition
{
    public bool cantransition;
    public BaseState To;
}
public enum StateType { Idle,Patrol,Chase,Attack,Dead,Victory}
