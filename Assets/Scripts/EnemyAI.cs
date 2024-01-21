using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Stats stats;
    Transform target;

    public void TakeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        if (stats.CurrentHealth <= 0) Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
