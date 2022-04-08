using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int PortalIndex;
    public string Scene;
    public PortalType portaltype;
    public PortalDsetination des;

    public GameObject InteractuveUI;
    public string ps = "拖拽挂载interactiveUI组件";

    bool canInteractive;

    private void Awake()
    {
        //使用代码查找UI组件时如果SetActive(false)会丢失对象
        //InteractuveUI = GameObject.FindWithTag("InteractiveUI");
        //if (InteractuveUI != null)
        //    InteractuveUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canInteractive && (portaltype == PortalType.Out || portaltype == PortalType.InAndOut))
                Transfer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && InteractuveUI != null)
        {
            InteractuveUI.SetActive(true);
            canInteractive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && InteractuveUI != null)
        {
            InteractuveUI.SetActive(false);
            canInteractive = false;
        }
    }
    void Transfer()
    {
        UIManager.Instance.OpenFade();
        Invoke("transferinvoke", 1f);
        
    }
    void transferinvoke()
    {
        SceneControl.Instance.TransitionToDestination(des.desScene, des.desPortal);
    }
}
public enum PortalType { In,Out,InAndOut}
[System.Serializable]
public class PortalDsetination
{
    public string desScene;
    public int desPortal;
}



