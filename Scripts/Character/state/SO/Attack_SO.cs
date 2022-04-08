using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackDate", menuName = "SO/Attack")]
public class Attack_SO : ScriptableObject
{
    public List<Combo> BaseAttack = new List<Combo>();
    public float skilldamage;
    public int comboindex = 0;
    public float attackdistance;
    public float critchance;
    public float critmultiply;
}

[System.Serializable]
public class Combo
{
    public float damage;

}
