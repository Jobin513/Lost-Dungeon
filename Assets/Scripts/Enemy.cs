using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public Animator animator;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


    // Start is called before the first frame update
    private void Start()
    {

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        this.enabled = false;
    }
}
