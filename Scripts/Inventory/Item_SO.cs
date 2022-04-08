using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="SO/Item")]
public class Item_SO : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public ItemType Type;
    public string Description;
    public bool canoverlay;
    public int price;
    public float hp;
    public Weapon wDate;
}

[System.Serializable]
public enum ItemType {Use,Equipment,Other};

[System.Serializable]
public class Weapon
{
    public Attack_SO WeaponAttack;
    public GameObject lweapon;
    public GameObject rweapon;
    public AnimatorOverrideController Wanim;
}
