using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
   
    float elapsedTime;
    float timeLimit = 5f;

    private void Update()
    { 
        

        if (hp <= 0)
        {
            Debug.Log("character died");
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeLimit)
            {
                elapsedTime = 0;
                Destroy(gameObject);
            }
            
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
