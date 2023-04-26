using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Attack_Parent : MonoBehaviour
{

    public int damage = 10;
    public int shieldDamage = 10;
    protected GameObject masterTower;
    protected Tower masterTowerScript;
    public int maxAttackCount = 1;
    public int comboAttackCount = 1;
    public float decreaseDamageRateComboAttack = 1f;

    public bool canAttackFly = false;
    public bool canAttackArmor = false;

    public bool isCold = false;
    public bool isBurn = false;
    public bool isChaos = false;
    public bool isStun = false;
    public bool isPushBack = false;


    public void SetDamage(int inputDamage, int inputShieldDamage = -1)
    {
        damage = inputDamage;
        shieldDamage = inputShieldDamage;
    }

    public void SetMasterTower(GameObject tower)
    {
        masterTower = tower;
        masterTowerScript = masterTower.GetComponent<Tower>();
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
