using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Transform cam;
    private GameObject bar;

    public GameObject healthbar;
    public Transform bar_pos;
    public float UIdistance;

    private void Awake()
    {
        cam = Camera.main.transform;
        foreach (Canvas canvas in FindObjectsOfType<Canvas>())
        {
            if (canvas.CompareTag("EnemyUI"))
            {
                bar = Instantiate(healthbar, canvas.transform);
                bar.SetActive(false);
            }
                
        }

    }
    private void Update()
    {
        if (bar != null)
        {
            bar.transform.position = bar_pos.position;
            bar.transform.forward = cam.forward;
            if (bar.GetComponent<EnemyHealthBar>().ReturnFillAmount())
                bar.SetActive(true);
        }
    }
    public void UpdateHealthBar(float maxhealth,float currenthealth)
    {
        if (bar != null)
        {
            bar.GetComponent<EnemyHealthBar>().UpdateHealthBar(maxhealth, currenthealth);
        }
    }
    public void DestroyBar()
    {
        if (bar != null)
            Destroy(bar);
    }
}
