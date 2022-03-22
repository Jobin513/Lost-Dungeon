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
        //Debug.Log(this.transform.position);
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

