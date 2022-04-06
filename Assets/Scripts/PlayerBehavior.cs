using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    // private float horizontalMovement;
    // private float verticalMovement;
    private Rigidbody2D rb;
    private Vector3 movement;
    private int targetDoor;
    //[SerializeField] private int hp = 10;


    // Start is called before the first frame update
    void Start()
    {
        
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(movement != Vector3.zero)
        {
            movePlayer();
        }

        if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

    }



    void movePlayer()
    {
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Enemy"))
        {
            Health playerHP = GetComponent<Health>();
            playerHP.Damage(1);
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

