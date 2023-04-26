using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerSecond : Attack_Parent
{
    [Header("Specific Attack")]
    [SerializeField] private Collider2D attackArea;

    int curAttackCount;

    private void Awake()
    {
        StartCoroutine("BlinkCollisionArea");        
    }


    IEnumerator BlinkCollisionArea()
    {        
        while (true)
        {
            curAttackCount = maxAttackCount;

            if (attackArea.enabled) attackArea.enabled = false;
            else attackArea.enabled = true;

            yield return new WaitForSeconds(0.3f);
        }        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyDamage(other.GetComponent<Enemy>());
        }
    }

    public void EnemyDamage(Enemy targetEnemy)
    {
        if ((targetEnemy.GetIsFly() && !canAttackFly) || curAttackCount == 0 || !targetEnemy.transform.gameObject.activeSelf) return;

        if (targetEnemy.GetIsHaveShield())
        {
            targetEnemy.Damage(shieldDamage);
        }
        else if (targetEnemy.GetIsArmor() && !canAttackArmor)
        {
            targetEnemy.Damage(0);
        }
        else
        {
            targetEnemy.Damage(damage, comboAttackCount, decreaseDamageRateComboAttack);
            targetEnemy.StatusEffect(isCold, isBurn, isChaos, isStun, isPushBack);
        }

        curAttackCount--;

        if(curAttackCount <= 0 ) attackArea.enabled = false;

    }
}
