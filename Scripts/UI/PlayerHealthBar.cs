using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthBar : MonoBehaviour
{
    public Text text;
    public Image bar_0;
    public Image bar_1;
    public Image Expbar;

    public void UpdateHealthBar(float maxhealth,float currenthealth)
    {
        text.text = currenthealth.ToString("0") + "/" + maxhealth.ToString("0");
        bar_1.fillAmount = currenthealth / maxhealth;
        bar_0.DOFillAmount(currenthealth / maxhealth, 1f);
    }
    public void UpdateExpbar(float maxExp,float exp)
    {
        Expbar.fillAmount = exp / maxExp;
    }
}
