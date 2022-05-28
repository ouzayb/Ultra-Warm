using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    
    public bool playerAlive = true;
    [SerializeField] private int id;
    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int playerCurrentHealth;
    [SerializeField] private float attackRange; // DEFAULT 0.5f
    [SerializeField] private float nextAttackTime; // DEFAULT 0f
    [SerializeField] private float attackRate; // DEFAULT 2f
    public int attackDamage; // DEFAULT 40


    void Update()
    {
        if(Time.time >= nextAttackTime && Input.GetAxis("Fire") == 1)
        {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack() 
    {
        animator.SetTrigger("PlayerAttack");
        //Invoke(nameof(AttackEnemies), 0.1f);
        AttackEnemies();
    }

    private void AttackEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        Debug.Log(hitEnemies.Length);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyManager>().EnemyTakeDamage(attackDamage);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        Debug.Log("Player Damaged");
        // Hit Animation

        if (playerCurrentHealth <= 0)
        {
            //animator.SetBool("IsDead", true);
            playerAlive = false;
            SceneManager.LoadScene(id);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}