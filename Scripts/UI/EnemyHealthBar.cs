using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyHealthBar : MonoBehaviour
{
    public Image bar0;
    public Image bar1;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        bar1.fillAmount = currentHealth / maxHealth;
        bar0.DOFillAmount(currentHealth / maxHealth, 1f);
    }
    public bool ReturnFillAmount()
    {
        if (bar1.fillAmount != 1)
            return true;
        else
            return false;
    }
}
