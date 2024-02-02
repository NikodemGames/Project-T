using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Stats stats;
    Transform target;

    private void Start()
    {
        target = Fortress.instance.transform;
    }
    public void TakeDamage(int damage)
    {
        stats.CurrentHealth -= damage;
        if (stats.CurrentHealth <= 0) Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if (target == null) return;
        transform.position = Vector3.MoveTowards(transform.position, target.position, stats.MoveSpeed * Time.deltaTime);

    }
}
