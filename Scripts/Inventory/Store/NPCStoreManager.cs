using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCStoreManager : MonoBehaviour
{
    public GameObject storePanel;
    public StoreGrid grid;
    public Inventory_SO storeDate;
    public Text pricetext;



    public void OpenStore()
    {
        storePanel.SetActive(true);
        UpdateStore();
    }
    public void ClosePanel()
    {
        storePanel.SetActive(false);
    }
    public void UpdateStore()
    {
        grid.UpdateGrid(storeDate.InventoryDate, this);
    }

    public void ShowPrice(int price)
    {
        pricetext.text = price.ToString();
    }
    public void ClosePrice()
    {
        pricetext.text = "";
    }
}
