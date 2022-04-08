using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewCharacterDate",menuName ="SO/CharacterState")]
public class CharacterState_SO : ScriptableObject
{
    public float maxHealth;
    public float currentHealth;
    public float currentdefense;
    public float exp;
    public float levelupexp;
    public float enemyexp;
}
