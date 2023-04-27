using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotOneKill : Attack_Parent
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyDamage(other.GetComponent<Enemy>());
        }
    }

    public void EnemyDamage(Enemy targetEnemy)
    {        

        targetEnemy.Dead();

        maxAttackCount--;

        if (maxAttackCount <= 0) Destroy(transform.root.gameObject);

    }
    
}
