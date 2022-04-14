using UnityEngine;
using System.Collections;

public class Bandit : Enemy {

 [SerializeField] float      m_speed = 4.0f;
  
    public GameObject swordArea; 
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Vector3 movement;
    private bool attacking = false; 
    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;
    private float timeToAttack = 1.5f;
    private float timer = 0f;
    private float direction;
    private float oldposition;
    private float minDist;
    private Vector3 initialPosition;
    // Use this for initialization
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        oldposition = transform.position.x;   
        initialPosition = transform.position;
    }
   
    // Update is called once per frame
    void Update () {
        CheckDistance();
        DeathAnimation();
       

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
           
            Debug.Log("enemy attack made");
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                m_animator.SetTrigger("Attack");
                attacking = false;
                swordArea.SetActive(attacking);
            }
        }

      if (Vector3.Distance(target.position, transform.position) <= attackRadius && attacking == false)
        {
            
            Attack();
           // attacking = true;
            Debug.Log("enemy attack made");
        }

        // -- Handle Animations --

        //Death
        if (Input.GetKeyDown("e")) {
            if(!m_isDead)
                m_animator.SetTrigger("Death");
            else
                m_animator.SetTrigger("Recover");

            m_isDead = !m_isDead;
        }

        //Hurt
     //   else if (banditHP.GetHealth())
     //       m_animator.SetTrigger("Hurt");
               
        //Combat Idle
      /*  else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
      */
    }

   private void DeathAnimation()
    {
        Health enemyHP = GetComponent<Health>();
        if (enemyHP.GetHealth() == 0)
            {
            m_isDead = true;
            m_animator.SetTrigger("Death");
            }
        
    }
    void CheckDistance()
    {
        //If player is in chase radius follow the player
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, m_speed * Time.deltaTime);
            m_animator.SetInteger("AnimState", 2);

        }
        //If player is past the chaseradius go back to idle animation
        if (Vector3.Distance(target.position, transform.position) >= chaseRadius)
        {
            m_animator.SetInteger("AnimState", 1);
        }
    }
    private void Attack()
    {
        attacking = true;

        if (attacking)
        {
            m_animator.SetTrigger("Attack");
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                swordArea.SetActive(attacking);
            }
        }
    }
}
