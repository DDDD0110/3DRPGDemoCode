using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float skillCD;
    public float skillChance;

    float temptime;
    public virtual bool CanUseSkill()
    {
        if (temptime < skillCD)
            return false;
        if (Random.Range(0, 1) < skillChance)
            return true;
        else
            return false;
    }

    public virtual void UseSkill()
    {
        temptime = 0f;
        GetComponent<Animator>().SetBool("skill",true);
    }

    public void SkillFinish()
    {
        GetComponent<Animator>().SetBool("skill", false);
    }

    private void Update()
    {
        temptime = temptime + Time.deltaTime;
    }
}
