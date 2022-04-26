using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    // private float horizontalMovement;
    // private float verticalMovement;
    public int maxhp;
    public int currenthp;
    private int direction;
    private Rigidbody2D rb;
    private Vector3 movement;
    private int targetDoor;
    public Animator animator;
    public Health hp;
    //[SerializeField] private int hp = 10;


    // Start is called before the first frame update
    void Start()
    {
        maxhp = hp.GetHealth();
        currenthp = hp.GetHealth();
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       if(currenthp > hp.GetHealth())
        {
            currenthp = hp.GetHealth();
            animator.SetTrigger("Hurt");
        }

        if (hp.GetHealth() > 0)
        {
            if (movement != Vector3.zero)
            {
                //animator.SetFloat("Run", movement);
                movePlayer();
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }

            if (movement.x > 0)
            {
                direction = 1;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (movement.x < 0)
            {
                direction = -1;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

      if(hp.GetHealth() <= 0)
        {
            movement = Vector3.zero;
            animator.SetTrigger("Death");
            this.enabled = false;

        }
    }

    public int getDirection()
    {
        return direction;
    }

    void movePlayer()
    {
        if (hp.GetHealth() > 0)
        {
            animator.SetInteger("AnimState", 1);
            rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        }       
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy") & hp.GetHealth() > 0)
        {
            Health playerHP = GetComponent<Health>();
            playerHP.Damage(1);
            animator.SetTrigger("Hurt");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Heart" & hp.GetHealth() < maxhp)
        {
            Health playerHP = GetComponent<Health>();
            int newhp = playerHP.GetHealth() + 1;
            playerHP.SetHealth(newhp);
            Debug.Log("Health Picked Up");
           // if (collision.gameObject.name == "Heart")
                Destroy(collision.gameObject);
        }
    }

    public int GetTargetDoor()
    {
        return targetDoor;
    }


    public void SetTargetDoor(int sceneNum)
    {
        targetDoor = sceneNum;
    }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    public void FindNewLocation()
    {

        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        GameObject targetDoorObject = null;
        //Debug.Log("number of doors:  " + doors.Length);
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetComponent<DoorBehavior>().id == GetTargetDoor())
            {
                //Debug.Log("this happened");
                targetDoorObject = doors[i];
            }
        }
        Debug.Log("Spawn Position:  " + targetDoorObject.GetComponent<DoorBehavior>().tran.position);
        transform.position = targetDoorObject.GetComponent<DoorBehavior>().tran.position;
        Debug.Log(transform.position);
    }
}

