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
        //Debug.Log(movement);
        if(movement != Vector3.zero)
        {
            movePlayer();
        }
        

        void movePlayer() {
            rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        }
    }




    public void FindNewLocation(DoorBehavior initialDoor)
    {

        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        GameObject targetDoor = null;
        Debug.Log("number of doors:  " + doors.Length);
        for (int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetComponent<DoorBehavior>().id == initialDoor.targetid)
            {
                Debug.Log("this happened");
                targetDoor = doors[i];
            }
        }
        Debug.Log("Spawn Position:  " + targetDoor.GetComponent<DoorBehavior>().tran.position);
        this.transform.position = targetDoor.GetComponent<DoorBehavior>().tran.position;
    }
}

