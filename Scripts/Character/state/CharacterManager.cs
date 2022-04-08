using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
{
    public CharacterState_SO statetemp;
    public Attack_SO attacktemp;

    //[HideInInspector]
    public CharacterState_SO characterstate;
    [HideInInspector]
    public Attack_SO attack;
    public event Action UpdateHealthBar;
    public event Action UpdateExpbar;

 

    private void Awake()
    {
        if (characterstate == null)
            characterstate = Instantiate(statetemp);
        if (attack == null)
            attack = Instantiate(attacktemp);
    }

    private void OnEnable()
    {
        RefreshPlayerUI();
    }
    #region setstate
    public float MaxHealth
    {
        get { if (characterstate != null) return characterstate.maxHealth;
            else return 0;}
        set { characterstate.maxHealth = value; }
    }
    public float CurrentHealth
    {
        get { if (characterstate != null) return characterstate.currentHealth;
            else return 0;}
        set { characterstate.currentHealth = value; }
    }
    public float Defense
    {
        get
        {
            if (characterstate != null) return characterstate.currentdefense;
            else return 0;
        }
        set { characterstate.currentHealth = value; }
    }
    public float Exp
    {
        get {if (characterstate != null) return characterstate.exp;
            else return 0;}
        set { characterstate.exp = value; }
    }
    public float LevelUpExp
    {
        get
        {
            if (characterstate != null) return characterstate.levelupexp;
            else return 0;
        }
        set { characterstate.levelupexp = value; }
    }
    #endregion

    public void GetHit(CharacterManager attacker ,bool skill)
    {
        float damage;
        if (skill)
            damage = attacker.attack.skilldamage;
        else
            damage = attacker.attack.BaseAttack[attacker.attack.comboindex].damage;
        if (damage - Defense >= 0)
            damage = damage - Defense;
        else
            damage = 0;
        if (UnityEngine.Random.Range(0, 1) <= attacker.attack.critchance)
            damage *= attacker.attack.critmultiply;
        if (CurrentHealth - damage >= 0)
            CurrentHealth -= damage;
        else
            CurrentHealth = 0;
        UpdateHealthBar?.Invoke();
    }
    public void GetExp(float exp)
    {
        Exp += exp;
        if (Exp > LevelUpExp)
        {
            LevelUp();
        }
        UpdateExpbar?.Invoke();

    }
    public void LevelUp()
    {
        LevelUpExp = LevelUpExp + LevelUpExp * 1.1f;
        MaxHealth = MaxHealth * 1.1f;
        CurrentHealth = MaxHealth;
        UpdateHealthBar?.Invoke();
    }

    //update血条，经验值条
    public void PlayerUIUpdate()
    {
        UpdateHealthBar?.Invoke();
        UpdateExpbar?.Invoke();
    }

    public void RefreshPlayerUI()
    {
        UpdateHealthBar?.Invoke();
        UpdateExpbar?.Invoke();

    }

}
