using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Attack_Parent
{

    private float lifeTime = 1f;
    private int bulletType = 0;
    [SerializeField] private bool autoDeactive_attckCount0 = true;

    void OnEnable()
    {
        StartCoroutine("RunLifeTime");        
    }

    IEnumerator RunLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);

        Deactivate();
    }

    void ReturnPool()
    {
        masterTowerScript.InPool(this.gameObject);
        transform.position = new Vector3(100, 200, 0);
        this.gameObject.SetActive(false);
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
        if ( (targetEnemy.GetIsFly() && !canAttackFly) || maxAttackCount == 0 || !targetEnemy.transform.gameObject.activeSelf) return;

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

        if (maxAttackCount == 0 || (targetEnemy.GetIsArmor() && !canAttackArmor))
        {            
            if(autoDeactive_attckCount0) Deactivate();
        }
    }

    public void Deactivate()
    {
        StopCoroutine("RunLifeTime");
        if (masterTowerScript.GetUsingBulletType() == bulletType) ReturnPool();
        else Destroy(this.gameObject);
    }

    public void SetLifeTime(float value)
    {
        lifeTime = value;
    }

    public void SetBulletType(int inputType)
    {
        bulletType = inputType;
    }
}
