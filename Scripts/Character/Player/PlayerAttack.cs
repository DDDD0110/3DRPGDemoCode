using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    BoxCollider col;
    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }
    //´ò¿ªÎäÆ÷´¥·¢Æ÷
    public void OpenCol()
    {
        col.enabled = true;
    }
    public void CloseCol()
    {
        col.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            FindObjectOfType<PlayerControl>().Hit(other.transform);
    
    }

}
