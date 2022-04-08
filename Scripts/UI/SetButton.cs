using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SetButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private Image button;
    private TextMeshProUGUI text;

    private void Awake()
    {
        button = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        SetColor(0.5f);
    }
    private void SetColor(float a)
    {
        Color color_b = new Color(1f, 1f, 1f, a);
        Color color_t = new Color((50f / 255f), (50f / 255f), (50f / 255f), a);
        button.color = color_b;
        text.color = color_t;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetColor(1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetColor(0.5f);
    }
}
