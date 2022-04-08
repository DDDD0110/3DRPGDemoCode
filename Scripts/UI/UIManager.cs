using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    private GameObject fade;
    public GameObject SetPanel;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
       //GameManager.Instance.UIRehister(transform.GetChild(0).gameObject);
        fade = transform.GetChild(2).gameObject;
    }
    public void ReturnMenu()
    {
        UIManager.Instance.OpenFade();
        Invoke("returnmenuinvoke", 1f);
    }
    void returnmenuinvoke()
    {
        SceneControl.Instance.ReturnMenu();
        GameManager.Instance.CloseEndGameUI();
    }
    public void OpenFade()
    {
        fade.SetActive(true);
        Invoke("CloseFade", 3.5f);
    }
    void CloseFade()
    {
        fade.SetActive(false);
    }
    public void CloseSetPanel()
    {
        SetPanel.SetActive(false);
    }
    public void OpenSetPanel()
    {
        SetPanel.SetActive(true);
    }
}
