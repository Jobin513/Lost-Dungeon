using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private bool sword = false;
    private bool bow = false;
    private bool shield = false;


    // Start is called before the first frame update
    void Start()
    {

        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SetWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SetWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (attacking)
        {
            Debug.Log("attack made");
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void SetWeapon(int weaponNum)
    {
        if (weaponNum == 1)
        {
            sword = true;
            bow = false;
            shield = false;
        }
        else if (weaponNum == 2)
        {
            sword = false;
            bow = true;
            shield = false;
        }
        else if (weaponNum == 3)
        {
            sword = false;
            bow = false;
            shield = true;
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
