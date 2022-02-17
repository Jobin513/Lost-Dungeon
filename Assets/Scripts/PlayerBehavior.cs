using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float speed = 1f;
    // private float horizontalMovement;
    // private float verticalMovement;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // horizontalMovement = Input.GetAxis("Horizontal") * speed;
        // verticalMovement = Input.GetAxis("Vertical") * speed;


        /*if (horizontalMovement > 0.1f || horizontalMovement < -0.1f) {
            rb.AddForce(new Vector2(horizontalMovement, 0), ForceMode2D.Impulse);
        }
        */

        if (Input.GetKeyDown("w")) {
            this.transform.Translate(new Vector3(0, speed , 0) * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyDown("a"))
        {
            this.transform.Translate(new Vector3(-speed , 0, 0) * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyDown("s"))
        {
            this.transform.Translate(new Vector3(0, -speed , 0) * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyDown("d"))
        {
            this.transform.Translate(new Vector3(speed , 0, 0) *Time.deltaTime, Space.World);
        }
        /*if (verticalMovement > 0.1f || verticalMovement < -0.1f)
        {
            rb.AddForce(new Vector2(0, verticalMovement), ForceMode2D.Impulse);
            //rb.transform.Translate(new Vector2(0, speed));
        }*/
    }
}
