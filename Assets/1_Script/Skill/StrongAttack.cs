using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : Attack_Parent
{
    [SerializeField] private GameObject attackEffect;


    public void EnemyDamage(Enemy targetEnemy)
    {
        if ((targetEnemy.GetIsFly() && !canAttackFly) || maxAttackCount == 0 || !targetEnemy.transform.gameObject.activeSelf) return;

        GameObject effectObj = Instantiate(attackEffect, new Vector3(targetEnemy.transform.position.x, targetEnemy.transform.position.y, 0), Quaternion.identity);
        effectObj.transform.localScale = new Vector3(0.7f,0.7f,1);

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
        
        
    }

}
