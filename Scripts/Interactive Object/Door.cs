using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public GameObject interactiveUI;
    public Log Log;
    public bool canInteractive;

    private void Update()
    {
        if (canInteractive && Input.GetKeyDown(KeyCode.F))
            OpenDoor();
    }
    public void OpenDoor()
    {
        Vector3 end = transform.localEulerAngles + new Vector3(0, 90, 0);

        if (InventoryManager.Instance.CheckItemNum("Key") > 0)
            transform.DOLocalRotate(end, 10f);
        else
        {
            Log.SetLog("È±ÉÙÔ¿³×!");
            Log.gameObject.SetActive(true);
        }
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
