using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehavior : MonoBehaviour
{
    private int damage = 2;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() != null)
        {
            Health hp = collision.GetComponent<Health>();
            hp.Damage(damage);

        }
    }
}
