using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
            if (elapsedTime >= timeLimit && gameObject.tag == "Enemy")
            {
                elapsedTime = 0;
                Destroy(gameObject);
            }
            if (elapsedTime >= timeLimit && gameObject.tag == "Player")
            {
                elapsedTime = 0;
                Destroy(gameObject);
                SceneManager.LoadScene(11);
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
