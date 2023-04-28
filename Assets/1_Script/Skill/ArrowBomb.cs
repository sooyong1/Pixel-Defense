using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBomb : Attack_Parent
{
    [SerializeField] private Collider2D attackArea;
    [SerializeField] private Collider2D explosionArea;
    //[SerializeField] private GameObject explosionArea;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject arrow;
    [SerializeField] private GoForward goForward;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            arrow.SetActive(false);
            explosionEffect.SetActive(true);
            explosionArea.enabled = true;
            //explosionArea.SetActive(true);
            attackArea.enabled = false;
            goForward.isActive = false;
            
            EnemyDamage(other.GetComponent<Enemy>());

           
        }
    }


    public void EnemyDamage(Enemy targetEnemy)
    {
        if ((targetEnemy.GetIsFly() && !canAttackFly) || maxAttackCount == 0 || !targetEnemy.transform.gameObject.activeSelf) return;

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

        maxAttackCount--;

        if (maxAttackCount <= 0) explosionArea.enabled = false;

    }

}
