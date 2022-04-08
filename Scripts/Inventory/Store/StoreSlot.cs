using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [HideInInspector]
    public NPCStoreManager store;
    private int price;
    public  void UpdateSlot(Item_SO item,NPCStoreManager s)
    {
        store = s;
        GetComponent<Image>().sprite = item.ItemImage;
        price = item.price;
    }
    public Inventory_SO GetItem()
    {
        if (store != null)
            return store.storeDate;
        else
            return null;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (store != null)
            store.ShowPrice(price);

    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        if (store != null)
            store.ClosePrice();
    }
    
}
