using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragitemOnStore : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    Transform oldparent;
    int oldindex;
    Transform dragpanel;

    private void Awake()
    {
        dragpanel = GameObject.FindGameObjectWithTag("DragPanel").transform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        oldparent = transform.parent;
        oldindex = oldparent.GetSiblingIndex();
        transform.SetParent(dragpanel);
        //transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (InventoryManager.Instance.CheckOnInventory(eventData.position))
            InventoryManager.Instance.BuyItem(GetComponent<StoreSlot>().GetItem().InventoryDate[oldindex].item);
        transform.SetParent(oldparent);
        GetComponent<StoreSlot>().store.UpdateStore();
        InventoryManager.Instance.UpdateInventoryUI();
    }
}
