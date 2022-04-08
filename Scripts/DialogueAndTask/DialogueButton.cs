using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueButton : MonoBehaviour
{
    Button button;
    DialogueNPCcontrol DNC;

    public Text text;
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ButtonClicked);
    }

    public void AnswerRegister(DialogueNPCcontrol dnc,string str,bool b=false)
    {
        DNC = dnc;
        text.text = str;
        if (b)
            text.text += "£®≤ªø…”√£©";
    }

    void ButtonClicked()
    {
        Debug.Log(transform.GetSiblingIndex() - 1);
        DNC.AnswerClick(transform.GetSiblingIndex()-1);
    }
}
