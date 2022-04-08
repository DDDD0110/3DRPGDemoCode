using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public Text text;

    bool CursorOnSlot = false;
    float lasttime = -1f;

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        CursorOnSlot = true;
        InventoryManager.Instance.ShowItemDes(transform.parent.GetSiblingIndex());
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        CursorOnSlot = false;
        InventoryManager.Instance.ClearDes();
    }

    public virtual void UpdateSlot(Item_SO item,int Num)
    {
        GetComponent<Image>().sprite = item.ItemImage;
        if (Num > 1)
        {
            text.gameObject.SetActive(true);
            text.text = Num.ToString();
        }
        else
            text.gameObject.SetActive(false);
    }
    protected virtual void Update()
    {
        if (CursorOnSlot && Input.GetMouseButtonDown(0) && Time.time - lasttime < 0.5f)
        {
            InventoryManager.Instance.ItemUse(transform.parent.GetSiblingIndex());
        }
        else if (CursorOnSlot && Input.GetMouseButtonDown(0))
            lasttime = Time.time;

        
    }

}
