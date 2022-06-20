using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Animator animator;
    public LayerMask enemyLayer;
    public Transform attackPoint;
    public HealthManager healthManager;
    public KnockbackManager knockbackManager;
    public SoundPlayer soundPlayer;
    public bool playerAlive = true;
    [SerializeField] private int id;
    [SerializeField] private float firingPenalty;
    [SerializeField] private float attackRange; // DEFAULT 0.5f
    [SerializeField] private float nextAttackTime; // DEFAULT 0f
    [SerializeField] private float attackRate; // DEFAULT 2f
    [SerializeField] private int attackPenalty;
    public int attackDamage; // DEFAULT 40

    void Start()
    {
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        //playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad >= nextAttackTime && Input.GetAxis("Fire") == 1 && playerAlive)
        {
            Attack();
            nextAttackTime = Time.timeSinceLevelLoad + 1f / attackRate;
            soundPlayer.playKatana();
        }
        if (healthManager.getHealth() <= 0 && playerAlive)
        {
            PlayerDie();
        }
        if (Input.GetKeyDown("r"))
        {
            PlayerDie();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("PlayerAttack");
        healthManager.getDamaged(attackPenalty);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<EnemyManager>().enemyAlive)
            {
                enemy.GetComponent<EnemyManager>().EnemyTakeDamage(attackDamage);
                if(enemy.GetComponent<EnemyManager>().enemyAlive) knockbackManager.Knock(transform, enemy.transform, 0.01f, 55f);
            }
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        healthManager.getDamaged(damage);
        if (healthManager.getHealth() > 0 )
        {
            animator.SetTrigger("GetDamage");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void PlayerDie()
    {
            animator.SetTrigger("OnDead");
            playerAlive = false;
        StartCoroutine(Reastart());
    }

    IEnumerator Reastart()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(0);

    }
}