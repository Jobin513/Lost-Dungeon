using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    private int damage = 2;


    private void OnTriggerEnter2D(CapsuleCollider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health hp = collision.GetComponent<Health>();
            hp.Damage(damage);
            Debug.Log("damage done");

        }
    }
}
