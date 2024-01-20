using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Stats stats;
    Animator animator;
    float attackCooldown;
    [SerializeField]
    private Transform _SpawnPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attackCooldown = stats.AttackSpeed;
        
    }
    public void HandleAttack(bool isAttacking)
    {
        if (isAttacking&&attackCooldown >=stats.AttackSpeed)
        {
            StartCoroutine(DoDamage(stats.Damage));
        }
    }
    IEnumerator DoDamage(int damage)
    {
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(1.67f);
        animator.SetBool("IsAttacking", false);
        attackCooldown = 0;
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
