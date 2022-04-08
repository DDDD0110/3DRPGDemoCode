using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGrid : MonoBehaviour
{
    public Image weaponsprite;
    public Item_SO weaponDate;

    private void OnEnable()
    {
        UpdateWeaponSlot();
    }
    public void UpdateWeaponDate(Item_SO weapon)
    {
        if (weapon != null)
            weaponDate = weapon;
        UpdateWeaponSlot();

    }
    public void UpdateWeaponSlot()
    {
        weaponsprite.gameObject.SetActive(true);
        weaponsprite.sprite = weaponDate.ItemImage;
    }
}
