using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform oldparent;
    int oldindex;
    int newindex;
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldparent = transform.parent;
        oldindex = oldparent.GetSiblingIndex();
        transform.SetParent(oldparent.parent.parent);
        //transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        newindex = InventoryManager.Instance.CheckOnSlot(eventData.position);
        if (newindex != -1)
            InventoryManager.Instance.SwapItem(oldindex, newindex);
        if (InventoryManager.Instance.CheckOnWeaponGrid(eventData.position))
            InventoryManager.Instance.WeaponEquipe(oldindex);
        if (InventoryManager.Instance.CheckOnStore(eventData.position))
            InventoryManager.Instance.SellItem(oldindex);
        transform.SetParent(oldparent);
        InventoryManager.Instance.UpdateInventoryUI();

    }
}
