using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public Text text;

    private void OnEnable()
    {
        Invoke("CloseLog", 1.5f);
    }
    public void SetLog(string str)
    {
        text.text = str;
    }
    private void CloseLog()
    {
        gameObject.SetActive(false);
    }
}
