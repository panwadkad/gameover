using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 10;
    protected PleyerStats playerStats;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerStats")) { 
            playerStats = collision.GetComponent<PleyerStats>();
            playerStats.TakeDamage(damage);

            SpacialAttack();
        }
    }

    public virtual void SpacialAttack() { 
    }
    
}
