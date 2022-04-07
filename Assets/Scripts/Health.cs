using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;


    private void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }


    public int GetHealth()
    {
        return hp;
    }


    public void SetHealth(int health)
    {
        hp = health;
    }


    public void Damage(int damage)
    {
        hp -= damage;
    }
}
