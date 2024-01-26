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
    [SerializeField] Transform _AttackPoint;

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
        yield return new WaitForSeconds(.8f);
        Vector3 boxSize = new Vector3(1.5f, .2f, 1);
        Collider[] enemiesHit = Physics.OverlapBox(_AttackPoint.position, boxSize);
        foreach (Collider c in enemiesHit)
        {
            if (c.GetComponent<EnemyAI>() != null)
            {
                Debug.Log(c.name + " Got hits for: " + damage);
                var enemy = c.GetComponent<EnemyAI>();
                enemy.TakeDamage(damage);
            }

        }
        yield return new WaitForSeconds(.87f);
       
        animator.SetBool("IsAttacking", false);
        attackCooldown = 0;
    }

    void OnDrawGizmos()
    {
        if (_AttackPoint == null)
            return;

        Gizmos.color = Color.red;

        Vector3 boxSize = new Vector3(1.2f, 0.2f, 1);
        Gizmos.DrawWireCube(_AttackPoint.position, boxSize);
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
