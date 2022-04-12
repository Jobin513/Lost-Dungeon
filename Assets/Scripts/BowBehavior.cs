using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehavior : MonoBehaviour
{
    private float speed = 3f;

    private int damage = 1;



    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerAttack")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            {
                Health hp = collision.gameObject.GetComponent<Health>();
                hp.Damage(damage);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
    }


}
