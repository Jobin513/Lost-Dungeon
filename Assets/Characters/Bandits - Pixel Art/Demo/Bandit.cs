using UnityEngine;
using System.Collections;

public class Bandit : Enemy
{

    //[SerializeField] float m_speed = 4.0f;

    public GameObject swordArea;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Health hp;
    public int maxhp;
    private bool attacking = false;
    private Animator m_animator;
    private Rigidbody2D m_body2d;

    private float timeToAttack = .5f;
    private float attackWindow = 2f;
    private float timer = 0f;
    private float oldposition;
    private Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {
        maxhp = hp.GetHealth();
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        oldposition = transform.position.x;
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        Attack();
        OnCollisionEnter2D();

        // -- Handle Animations --

        if (hp.GetHealth() <= 0)
        {
            m_animator.SetTrigger("Death");
        }

        // Moving Left
        if (transform.position.x > oldposition)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        //Moving Right
        if (transform.position.x < oldposition)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        oldposition = transform.position.x;

        if (attacking)
        {
            timer += Time.deltaTime;

          if (timer >= attackWindow)
            {
              timer = 0;
              swordArea.SetActive(false);
              attacking = false;
            }
        }

    }

    private void OnCollisionEnter2D()
    {
        if (hp.GetHealth() < maxhp)
        {
            maxhp = hp.GetHealth();
            animator.SetTrigger("Hurt");
        }
    }

    void Attack()
    {
        if (Vector3.Distance(target.position, transform.position) <= attackRadius && attacking == false)
        {
            timer += Time.deltaTime;
            if (timer <= timeToAttack)
            {
                attacking = true;
                swordArea.SetActive(true);
                m_animator.SetTrigger("Attack");
               
                timer = 0;
                Debug.Log("enemy attack made");
            }
        }
        
    }
    void CheckDistance()
    {
        if (hp.GetHealth() > 0)
        {
            //If player is in chase radius follow the player
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius
                && Vector3.Distance(target.position, transform.position) > attackRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                m_animator.SetInteger("AnimState", 2);               
            }

            //If player is past the chaseradius go back to idle animation
            if (Vector3.Distance(target.position, transform.position) >= chaseRadius)
            {
                m_animator.SetInteger("AnimState", 1);
            }
        }
    }
}
