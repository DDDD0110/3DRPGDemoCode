using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    public Inventory_SO inventorytemp;
    [HideInInspector]
    public Inventory_SO InventoryDate;
    public GameObject InventortPanel;
    public GridPanel gridpanel;
    public ItemDescription itemdes;
    public Transform WeaponGrid;
    public Text goldnum;
    public Log log;
    public RectTransform InventoryPanel;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        if (InventoryDate == null)
            InventoryDate = Instantiate(inventorytemp);
    }

    public void InitializeInventory()
    {
        InventoryDate = Instantiate(inventorytemp);
    }

    public void UpdateInventoryUI()
    {
        gridpanel.UpdateGrid(InventoryDate.InventoryDate);
        UpdateGoldNum();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            OpenInventory();
    }
    public void CloseInventory()
    {
        InventortPanel.SetActive(false);
    }
    public void OpenInventory()
    {
        if (SceneControl.Instance.RetuenSceneName() == "MENU")
            return;
        InventortPanel.SetActive(true);
        UpdateInventoryUI();
    }
    public void TakeItem(Item_SO item)
    {
        if (item.canoverlay)
            foreach (var date in InventoryDate.InventoryDate)
            {
                if (date.item!=null && date.item.ItemName == item.ItemName)
                {
                    date.Num++;
                    return;
                }
            }

        foreach (var date in InventoryDate.InventoryDate)
        {
            if (date.item == null)
            {
                date.item = item;
                date.Num = 1;
                break;
            }
        }
        UpdateInventoryUI();
        TaskManager.Instance.UpdateCollectTaskProgress();
    }
    //检测pos是否在某个slot上,返回-1表示无
    public int CheckOnSlot(Vector2 pos)
    {
        int count = gridpanel.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            RectTransform rt = gridpanel.transform.GetChild(i) as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(rt, pos))
                return i;
        }

        return -1;
    }
    //检测pos是否在装备栏上,返回-1表示无
    public bool CheckOnWeaponGrid(Vector2 pos)
    {
        RectTransform rt = WeaponGrid as RectTransform;
        if (RectTransformUtility.RectangleContainsScreenPoint(rt, pos))
            return true;
        return false;
    }
    //判断pos是否处于商店
    public bool CheckOnStore(Vector2 pos)
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Store");
        if (obj != null)
        {
            RectTransform rt = obj.transform as RectTransform;
            if (RectTransformUtility.RectangleContainsScreenPoint(rt, pos))
                return true;
        }
        return false;
    }
    //交换物品
    public void SwapItem(int index1, int index2)
    {
        if (index1 == index2)
            return;
        if (InventoryDate.InventoryDate[index2].item != null
            && InventoryDate.InventoryDate[index1].item.ItemName == InventoryDate.InventoryDate[index2].item.ItemName 
            && InventoryDate.InventoryDate[index1].item.canoverlay)
        {
            InventoryDate.InventoryDate[index2].Num++;
            InventoryDate.InventoryDate[index1].item = null;
            InventoryDate.InventoryDate[index1].Num = 0;
        }
        else
        {
            var temp = InventoryDate.InventoryDate[index1];
            InventoryDate.InventoryDate[index1] = InventoryDate.InventoryDate[index2];
            InventoryDate.InventoryDate[index2] = temp;
        }
    }
    //卖物品
    public void SellItem(int index)
    {
        if (InventoryDate.InventoryDate[index].item.price == 0)
        {
            log.SetLog("不可出售");
            log.gameObject.SetActive(true);
            return;
        }
        InventoryDate.gold += InventoryDate.InventoryDate[index].item.price * InventoryDate.InventoryDate[index].Num;
        InventoryDate.InventoryDate[index].item = null;
        InventoryDate.InventoryDate[index].Num = 0;
    }

    public bool CheckOnInventory(Vector2 pos)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(InventoryPanel, pos))
            return true;
        return false;
    }
    //买物品
    public void BuyItem(Item_SO item)
    {
        if (item == null)
            return;
        if (InventoryDate.gold >= item.price)
        {
            InventoryDate.gold -= item.price;
            TakeItem(item);
        }
        else
        {
            log.SetLog("金币不足");
            log.gameObject.SetActive(true);
        }    
    }
    public void ShowItemDes(int i)
    {
        if (InventoryDate.InventoryDate[i].item != null)
            itemdes.ShowDes(InventoryDate.InventoryDate[i].item.Description);
    }
    public void ClearDes()
    {
        itemdes.ClearDes();
    }
    public void ItemUse(int i)
    {
        if (InventoryDate.InventoryDate[i].item.Type != ItemType.Use)
            return;
        GameManager.Instance.PlayerHealthReply(InventoryDate.InventoryDate[i].item.hp);
        InventoryDate.InventoryDate[i].Num--;
        if (InventoryDate.InventoryDate[i].Num == 0)
            InventoryDate.InventoryDate[i].item = null;
        UpdateInventoryUI();
    }

    //装备武器
    public void WeaponEquipe(int index)
    {
        Item_SO weapon = InventoryDate.InventoryDate[index].item;
        if (weapon.Type!=ItemType.Equipment)
            return;
        InventoryDate.InventoryDate[index].item = WeaponGrid.GetComponent<WeaponGrid>().weaponDate;
        InventoryDate.InventoryDate[index].Num = 1;
        WeaponGrid.GetComponent<WeaponGrid>().UpdateWeaponDate(weapon);
        GameManager.Instance.ChangerPlayerWeapon(weapon);

    }
    //返回物品数量
    public int CheckItemNum(string itemName)
    {
        int n = 0;
        for (int i = 0; i < InventoryDate.InventoryDate.Count; i++)
        {
            if (InventoryDate.InventoryDate[i].item!=null && InventoryDate.InventoryDate[i].item.ItemName == itemName)
                n += InventoryDate.InventoryDate[i].Num;
        }
        return n;
    }
    public void RemoveItem(string itemName, int n)
    {
        for (int i = 0; i < InventoryDate.InventoryDate.Count; i++)
        {
            if (InventoryDate.InventoryDate[i].item!=null && InventoryDate.InventoryDate[i].item.ItemName == itemName)
            {
                if (InventoryDate.InventoryDate[i].Num >= n)
                {
                    InventoryDate.InventoryDate[i].Num -= n;
                    if (InventoryDate.InventoryDate[i].Num == 0)
                        InventoryDate.InventoryDate[i].item = null;
                    break;
                }
                else
                {
                    n -= InventoryDate.InventoryDate[i].Num;
                    InventoryDate.InventoryDate[i].Num = 0;
                    InventoryDate.InventoryDate[i].item = null;
                }
            }
        }
        UpdateInventoryUI();
    }

    public Item_SO GetWeaponDate()
    {
        return WeaponGrid.GetComponent<WeaponGrid>().weaponDate;
    }

    //显示拥有的金钱
    public void UpdateGoldNum()
    {
        goldnum.text = InventoryDate.gold.ToString();
    }

}
