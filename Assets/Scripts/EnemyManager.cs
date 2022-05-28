using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Animator animator;

    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int damageTaken;
    public CombatManager combatManager;

    void Start()
    {
        currentHealth = maxHealth;
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

    public void TakeDamage()
    {
        currentHealth -= combatManager.attackDamage;

        if (currentHealth <= 0)
        {
            animator.SetBool("IsDead", true);
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
        }
    }
}
