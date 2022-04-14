using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    public GameObject swordArea;
    public Transform target;
    public float attackRadius;
    private bool attacking = false;

    private float timeToAttack = 1f;
    private float timer = 0f;

    public Animator animator;
 
    // Start is called before the first frame update
    void Start()
    {

        //swordArea = transform.GetChild(0).gameObject;
        //shieldArea = transform.GetChild(2).gameObject;
      //  SetWeapon(1);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= attackRadius && attacking == false)
        {
            Attack();
            Debug.Log("enemy attack made");
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

    private void Attack()
    {
            attacking = true;     
            animator.SetTrigger("Attack");
            swordArea.SetActive(attacking);
    }
}
