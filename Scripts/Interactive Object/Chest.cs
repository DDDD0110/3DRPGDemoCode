using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject interactiveUI;
    public Item_SO rewards;
    bool canInteractive;
    private void Update()
    {
        if (canInteractive && Input.GetKeyDown(KeyCode.F))
            OpenChest();
    }
    //�򿪱��䣬��ý������Ƴ�����
    public void OpenChest()
    {
        InventoryManager.Instance.TakeItem(rewards);
        interactiveUI.SetActive(false);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactiveUI.SetActive(true);
            canInteractive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactiveUI.SetActive(false);
            canInteractive = false;
        }
    }
}
