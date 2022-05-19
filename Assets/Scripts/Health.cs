using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    public static Health instance;
    float elapsedTime;
    float timeLimit = 5f;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
    public int numOfHearts;
    

    
    private void Update()
    { 
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < hp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (hp <= 0)
        {
            Debug.Log("character died");
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeLimit && gameObject.tag == "Enemy")
            {
                elapsedTime = 0;
                
                Destroy(gameObject);

                ScoreManager.instance.AddPoint();
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
