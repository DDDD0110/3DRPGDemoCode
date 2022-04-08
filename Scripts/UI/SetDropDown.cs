using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDropDown : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Dropdown>().onValueChanged.AddListener(Change);
    }
    public void Change(int i)
    {
        if (i == 0)
            GameManager.Instance.ChangePlayerControl(false);
        else
            GameManager.Instance.ChangePlayerControl(true);
    }
}
