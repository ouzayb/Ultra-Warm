using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Animator animator;
    public CombatManager combatManager;

    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private int enemyCurrentHealth;

    void Start()
    {
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
        Debug.Log("Damaged");
        // Hit Animation

        if (enemyCurrentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
}
