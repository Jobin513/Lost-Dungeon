using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject swordArea;
    public GameObject shieldArea;
    private bool attacking = false;

    private float timeToAttack = .5f;
    private float timer = 0f;



    private bool sword = false;
    private bool bow = false;
    private bool shield = false;


    public Animator animator;
    public BowBehavior arrowPrefab;
    public Transform arrowOffset;




    // Start is called before the first frame update
    void Start()
    {

        //swordArea = transform.GetChild(0).gameObject;
        //shieldArea = transform.GetChild(2).gameObject;
        SetWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(3);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && attacking == false)
        {
            Attack();
            Debug.Log("attack made");
        }

        if (attacking)
        {
            //Debug.Log("attack made");
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                //attackArea.SetActive(attacking);
            }
        }
    }

    private void SetWeapon(int weaponNum)
    {
        if (weaponNum == 1)
        {
            Debug.Log("sword in use");
            sword = true;
            bow = false;
            shield = false;
        }
        else if (weaponNum == 2)
        {
            Debug.Log("bow in use");
            sword = false;
            bow = true;
            shield = false;
        }
        else if (weaponNum == 3)
        {
            Debug.Log("shield in use");
            sword = false;
            bow = false;
            shield = true;
        }
    }
    private void Attack()
    {
        attacking = true;
        if (sword == true)
        {
            animator.SetTrigger("Attack1");
            swordArea.SetActive(attacking);
        }
        else if (bow == true)
        {
            Instantiate(arrowPrefab, arrowOffset.position, transform.rotation);
        }
        else if (shield == true)
        {
            animator.SetTrigger("Block");
            shieldArea.SetActive(attacking);
        }
        
    }
}
