using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public Animator animator;
    public CombatManager combatManager;
    public bool facingLeft = true;

    [SerializeField] private int enemySpeed;
    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private int enemyCurrentHealth;
    [SerializeField] private int enemyDamage;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCurrentHealth = enemyMaxHealth;
    }

    void Update()
    {
    
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
            //animator.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }

    private void FollowPlayer()
    {
        animator.SetFloat("EnemySpeed", Mathf.Abs(enemySpeed));
        float difference = transform.position.x - combatManager.gameObject.transform.position.x;
        if (combatManager.playerAlive && difference < 0)
        {
            facingLeft = !facingLeft;
            Vector3 tempLocalScale = transform.localScale;
            tempLocalScale.x *= -1;
            transform.localScale = tempLocalScale;
        }
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
}
