using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item_SO itemDate;

    bool hastaken = false;

    //处于场景的物品，player触碰后捡起
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!hastaken)
            {
                hastaken = true;
                InventoryManager.Instance.TakeItem(itemDate);
                Destroy(gameObject);
            }
        }
    }
}
