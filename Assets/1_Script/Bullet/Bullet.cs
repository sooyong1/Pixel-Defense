using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage = 0;
    private int shieldDamage = 0;
    private GameObject masterTower;
    private Tower masterTowerScript;
    private float lifeTime = 1f;
    private int maxAttackCount = 1;
    private int bulletType = 0;
    private int comboAttackCount = 1;
    private float decreaseDamageRateComboAttack = 1f;

    [Header("Specific Attack")]
    private bool canAttackFly = false;
    private bool canAttackArmor = false;

    private bool isCold = false;
    private bool isBurn = false;
    private bool isChaos = false;
    private bool isStun = false;
    private bool isPushBack = false;

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
            Deactivate();
        }
    }

    public void Deactivate()
    {
        StopCoroutine("RunLifeTime");
        if (masterTowerScript.GetUsingBulletType() == bulletType) ReturnPool();
        else Destroy(this.gameObject);
    }

    public void SetDamage(int inputDamage, int inputShieldDamage = -1)
    {
        damage = inputDamage;

        if (inputShieldDamage == -1) shieldDamage = (int)(inputDamage * 0.2);
        else shieldDamage = inputDamage * inputShieldDamage;

    }

    public void SetMasterTower(GameObject tower)
    {
        masterTower = tower;
        masterTowerScript = masterTower.GetComponent<Tower>();
    }
    public void SetLifeTime(float value)
    {
        lifeTime = value;
    }
    public void SetCanAttackFly(bool isCan)
    {
        canAttackFly = isCan;
    }
    public void SetCanAttackArmor(bool isCan)
    {
        canAttackArmor = isCan;
    }
    public void SetMaxAttackCount(int value)
    {
        maxAttackCount = value;
    }
    public void SetBulletType(int inputType)
    {
        bulletType = inputType;
    }
    public void SetComboAttackCount(int value)
    {
        comboAttackCount = value;
    }

    public void StatusEffect(bool inputIsCold, bool inputIsBurn, bool inputIsChaos, bool inputIsStun, bool inputIsPushBack)
    {
        isCold = inputIsCold;
        isBurn = inputIsBurn;
        isChaos = inputIsChaos;
        isStun = inputIsStun;
        isPushBack = inputIsPushBack;
    }
}
