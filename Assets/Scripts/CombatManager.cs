using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;

    public LayerMask enemyLayer;

    [SerializeField] private float attackRange;
    [SerializeField] private float time;
    public int attackDamage; 

    public float Time
    {
        get
        {
            return time;
        }
        set
        {
            if (value > 0) time = value;
            else time = 0;
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    void HitInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("Attack");
        Invoke(nameof(AttackEnemies), 0.1f);
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        //Gizmos.DrawCircle(attackPoint.position, attackRange);
    }

    private void AttackEnemies()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyManager>().TakeDamage();
        }
    }
}

