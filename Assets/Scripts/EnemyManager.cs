using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D enemyRB;
    public Animator animator;
    public CombatManager combatManager;
    public bool facingLeft = true;

    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private int enemyCurrentHealth;
    [SerializeField] private int enemyDamage;
    [SerializeField] private float followRange;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCurrentHealth = enemyMaxHealth;
    }

    void Update()
    {
        animator.SetFloat("EnemySpeed", Mathf.Abs(enemyRB.velocity.x));
        float difference = transform.position.x - target.position.x;
        if(Math.Abs(difference) < followRange)
        {
        FollowPlayer();
        }
        else
        {
            enemyRB.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            throw new NotImplementedException();
        }
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        Debug.Log("Enemy Damaged");
        // Hit Animation

        if (enemyCurrentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            //GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }

    private void FollowPlayer()
    {
        float difference = transform.position.x - target.position.x;
        if (combatManager.playerAlive && difference < 0)
        {
            enemyRB.velocity = new Vector2(enemySpeed, 0);
            if (facingLeft) 
            { 
            facingLeft = !facingLeft;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
            }
        }
        else
        {
            enemyRB.velocity = new Vector2(-enemySpeed, 0);
            if(!facingLeft)
            {
            facingLeft = !facingLeft;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
            }  
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followRange);
    }

    public void AttackPlayer()
    {
        combatManager.GetComponent<CombatManager>().PlayerTakeDamage(enemyDamage);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            AttackPlayer();
        }
    }

    public void EnemyDie()
    {

    }
}
