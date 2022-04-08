using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDescription : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ShowDes(string str)
    {
        text.text = str;
    }
    public void ClearDes()
    {
        text.text = "";
    }
}
