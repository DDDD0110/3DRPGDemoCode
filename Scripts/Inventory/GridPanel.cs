using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPanel : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Slot;

    public  void UpdateGrid(List<ItemDate> inventory)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < inventory.Count; i++)
        {
            var grid = Instantiate(Grid, transform);
            var slot = Instantiate(Slot, grid.transform);
            if (inventory[i].item != null)
                slot.GetComponent<Slot>().UpdateSlot(inventory[i].item,inventory[i].Num);
            else
                slot.SetActive(false);
        }
    }
}
