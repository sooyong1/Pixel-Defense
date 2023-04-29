using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Worrior : Tower
{
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(SetUpgrade_Level1_Type1);
        SetUpgrade2Function(null);

        SetUpgradePrice1(new int[] { 2, 0, 0, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });

        SetUpgrade1Info("Increase damage.");
        SetUpgrade2Info("");
    }


    protected override void DefaultAttack()
    {
        float angle = LookTargetAngle();

        GameObject outbullet = OutPool();
        outbullet.transform.position = firePosition.position;
        outbullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    /// Level 1

    protected override void SetUpgrade_Level1_Type1()
    {
        //데미지 증가        
        attackDamage += 35;

        SetUpgrade1Function(SetUpgrade_Level1_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Worrior can destroy armor.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level1_Type1_Elite()
    {
        //공격범위 증가, 아머 공격 가능
        canAttackArmor = true;
        AddAttackRange(0.3f);
        attackDamage += 20;

        SetUpgrade1Function(SetUpgrade_Level2_Type1);
        SetUpgradePrice1(new int[] { 4, 0, 0, 2 });
        SetUpgrade1Info("Hit many times with one attack.");

        SetUpgrade2Function(SetUpgrade_Level2_Type2);
        SetUpgradePrice2(new int[] { 4, 2, 0, 0 });
        SetUpgrade2Info("Push enemies.");
    }

    /// Level 2
    protected override void SetUpgrade_Level2_Type1()
    {
        ChangeSkin(1);

        //한번의 공격으로 여러번 타격
        attackDamage = (int)(attackDamage / 3);
        comboAttackCount = 5;
        maxAttackCount = 2;

        SetUpgrade1Function(SetUpgrade_Level2_Type1_Elite);
        SetUpgradePrice1(new int[] { 4, 0, 4, 2 });
        SetUpgrade1Info("Increase attack range.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level2_Type2()
    {
        ChangeSkin(2);

        //공격시 뒤로 밀리게함.
        isPushBack = true;
        attackDamage += 70;
        maxAttackCount = 2;

        SetUpgrade1Function(SetUpgrade_Level2_Type2_Elite);
        SetUpgradePrice1(new int[] { 4, 4, 0, 2 });
        SetUpgrade1Info("Sword aura pierces the enemy.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    protected override void SetUpgrade_Level2_Type1_Elite()
    {
        //공격범위 증가
        AddAttackRange(1f);
        attackDamage += 10;        

        SetUpgrade1Function(SetUpgrade_Level3_Type1);
        SetUpgradePrice1(new int[] { 6, 6, 0, 4 });
        SetUpgrade1Info("Skill : Shouting");

        SetUpgrade2Function(SetUpgrade_Level3_Type2);
        SetUpgradePrice2(new int[] { 6, 0, 6, 4 });
        SetUpgrade2Info("Skill : ");
    }

    protected override void SetUpgrade_Level2_Type2_Elite()
    {
        //최대 동시공격 3
        maxAttackCount = 3;
        attackDamage += 50;

        SetUpgrade1Function(SetUpgrade_Level3_Type3);
        SetUpgradePrice1(new int[] { 6, 2, 2, 6 });
        SetUpgrade1Info("Skill : Power strike");

        SetUpgrade2Function(SetUpgrade_Level3_Type4);
        SetUpgradePrice2(new int[] { 6, 3, 3, 4 });
        SetUpgrade2Info("Skill : ");
    }


    /// upgrade3


    protected override void SetUpgrade_Level3_Type1()
    {
        ChangeSkin(3);

        SetSkill(Skill1, skill1CoolTime);
        isSkillReady = true;

        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type2()
    {
        ChangeSkin(4);

        SetSkill(Skill2, skill2CoolTime);
        isSkillReady = true;

        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type3()
    {
        ChangeSkin(5);

        SetCurrentAttackFunction(UpgradeAttack_Leve3_Tyep3);

        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type4()
    {
        ChangeSkin(6);

        SetSkill(Skill4, skill4CoolTime);
        isSkillReady = true;

        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    //Default Attack Upgrade

    protected override void UpgradeAttack_Leve3_Tyep3() 
    {
        int skillPercnet = 3;

        if(Random.Range(1,10) <= skillPercnet)
        {
            Skill3();
        }
        else
        {
            float angle = LookTargetAngle();

            GameObject outbullet = OutPool();
            outbullet.transform.position = firePosition.position;
            outbullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }        
    }

    //Skill
    protected override void Skill1()
    {        
        GameObject skillObj = Instantiate(towersAllSkill[0], new Vector3(transform.root.position.x, transform.root.position.y, 0), Quaternion.identity);
        Attack_Parent skillObjScript = skillObj.GetComponent<Attack_Parent>();

        skillObjScript.SetMasterTower(this.gameObject);
        skillObjScript.SetDamage(attackDamage, attackDamage + (int)(attackDamage * attackShieldDamageRate));
        skillObjScript.SetCanAttackFly(canAttackFly);
        skillObjScript.SetCanAttackArmor(canAttackArmor);
        skillObjScript.SetMaxAttackCount(8);
        skillObjScript.SetComboAttackCount(comboAttackCount);
        skillObjScript.StatusEffect(false, false, false, true, false);        

    }

    protected override void Skill2()
    {

    }


    protected override void Skill3()
    {
        GameObject skillObj = Instantiate(towersAllSkill[2], new Vector3(transform.root.position.x, transform.root.position.y, 0), Quaternion.identity);
        StrongAttack skillObjScript = skillObj.GetComponent<StrongAttack>();

        skillObjScript.SetMasterTower(this.gameObject);
        skillObjScript.SetDamage(attackDamage * 5, (attackDamage * 5) + (int)((attackDamage * 5) * attackShieldDamageRate));
        skillObjScript.SetCanAttackFly(canAttackFly);
        skillObjScript.SetCanAttackArmor(canAttackArmor);
        skillObjScript.SetMaxAttackCount(1);
        skillObjScript.SetComboAttackCount(1);

        skillObjScript.EnemyDamage(target.GetComponent<Enemy>());
    }

    protected override void Skill4()
    {


    }
}
