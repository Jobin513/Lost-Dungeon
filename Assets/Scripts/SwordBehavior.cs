using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    private int damage = 2;
   

    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.GetComponent<Health>() != null)
        {
            Health hp = col.gameObject.GetComponent<Health>();
            hp.Damage(damage);
            Debug.Log("damage done");

        }
    }
}
