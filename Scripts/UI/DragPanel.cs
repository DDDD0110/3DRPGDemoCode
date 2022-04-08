using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPanel : MonoBehaviour, IDragHandler
{
    RectTransform recttransform;
    public Canvas canvas;
    private void Awake()
    {
        recttransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        recttransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

}
