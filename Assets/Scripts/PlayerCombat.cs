using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Stats stats;
    float attackCooldown;
    [SerializeField]
    private Transform _SpawnPoint;

    private void Start()
    {
        attackCooldown = stats.AttackSpeed;
        
    }
    public void HandleAttack(bool isAttacking)
    {
        attackCooldown = stats.AttackSpeed;
        if (isAttacking&&attackCooldown >=stats.AttackSpeed)
        {
            Debug.Log("Player attack");
            attackCooldown = 0;
        }
    }

    private void Update()
    {
        if(attackCooldown < stats.AttackSpeed)
        {
            attackCooldown += Time.deltaTime;
        }

    }
    public void TakeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        if(stats.CurrentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        GameManager.instance.SwitchGameMode();
    }
}
