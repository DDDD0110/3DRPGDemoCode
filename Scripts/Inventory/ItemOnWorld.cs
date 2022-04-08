using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item_SO itemDate;

    bool hastaken = false;

    //���ڳ�������Ʒ��player���������
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
