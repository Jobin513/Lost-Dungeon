using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBehavior : MonoBehaviour
{
    private float speed = 10f;

    private int scale;

    private int damage = 1;

    private GameObject player;
    public SpriteRenderer spr;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        scale = player.GetComponent<PlayerBehavior>().getDirection();
        if (scale == -1)
        {
            spr.flipX = true;
        }
        else
        {
            spr.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed * scale;
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
