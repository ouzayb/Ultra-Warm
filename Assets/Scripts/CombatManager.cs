using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    HealthManager healthManager;
    public bool playerAlive = true;
    [SerializeField] private int id;
    //[SerializeField] private int playerCurrentHealth;
    //[SerializeField] private int playerMaxHealth;
    [SerializeField] private float firingPenalty;
    [SerializeField] private float attackRange; // DEFAULT 0.5f
    [SerializeField] private float nextAttackTime; // DEFAULT 0f
    [SerializeField] private float attackRate; // DEFAULT 2f
    public int attackDamage; // DEFAULT 40

    void Start()
    {
        animator = GetComponent<Animator>();
        //playerCurrentHealth = playerMaxHealth;
    }

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
        animator.SetTrigger("PlayerAttack");
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyManager>().EnemyTakeDamage(attackDamage);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        /*playerCurrentHealth -= damage;
        Debug.Log("Player Damaged");
        // Hit Animation

        if (playerCurrentHealth <= 0)
        {
            animator.SetTrigger("OnDead");
            playerAlive = false;
            //SceneManager.LoadScene(id);
        }*/
        healthManager.getDamaged(damage);
        if (healthManager.getHealth() == 0)
        {
            animator.SetTrigger("OnDead");
            playerAlive = false;
            //SceneManager.LoadScene(id);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}