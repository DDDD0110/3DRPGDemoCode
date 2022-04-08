using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="SO/Inventory")]
public class Inventory_SO : ScriptableObject
{
    public int gold;
    public List<ItemDate> InventoryDate = new List<ItemDate>();
}
[System.Serializable]
public class ItemDate
{
    public Item_SO item;
    public int Num;
}