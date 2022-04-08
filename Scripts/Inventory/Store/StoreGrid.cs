using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGrid : MonoBehaviour
{
    public GameObject Grid;
    public GameObject Slot;

    public void UpdateGrid(List<ItemDate> inventory,NPCStoreManager store)
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
                slot.GetComponent<StoreSlot>().UpdateSlot(inventory[i].item, store);
            else
                slot.SetActive(false);
        }
    }
}
