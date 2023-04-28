using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Archer : Tower
{
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(SetUpgrade_Level1_Type1);
        SetUpgrade2Function(null);

        SetUpgradePrice1(new int[] { 2, 0, 0, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });

        SetUpgrade1Info("Increases attack range.");
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
        //공격범위 증가, 데미지 증가
        AddAttackRange(0.3f);
        attackDamage += 20;

        SetUpgrade1Function(SetUpgrade_Level1_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Archer can attack flying enemy.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level1_Type1_Elite()
    {
        //데미지 증가, 공중 공격 가능
        attackDamage += 20;
        canAttackFly = true;

        SetUpgrade1Function(SetUpgrade_Level2_Type1);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Archer shoots three arrows.");

        SetUpgrade2Function(SetUpgrade_Level2_Type2);
        SetUpgradePrice2(new int[] { 0, 2, 0, 2 });
        SetUpgrade2Info("Arrow pierces the enemy.");
    }

    /// Level 2
    protected override void SetUpgrade_Level2_Type1()
    {
        ChangeSkin(1);
        //기본공격 강화, 데미지 증가, 범위 증가
        SetCurrentAttackFunction(UpgradeAttack_Leve2_Tyep1);
        attackDamage += 50;
        AddAttackRange(0.3f);

        SetUpgrade1Function(SetUpgrade_Level2_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("Increases attack speed.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level2_Type2()
    {
        ChangeSkin(2);
        //총알 종류 변화, 탄환 최대 공격 가능 수 3
        SetUsingBulletType(1);
        maxAttackCount = 3;

        SetUpgrade1Function(SetUpgrade_Level2_Type2_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
        SetUpgrade1Info("Arrow pierces armor.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    protected override void SetUpgrade_Level2_Type1_Elite()
    {
        //공격 속도 증가
        attackRate -= 0.3f;

        SetUpgrade1Function(SetUpgrade_Level3_Type1);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("Skill : Arrow rain");

        SetUpgrade2Function(SetUpgrade_Level3_Type2);
        SetUpgradePrice2(new int[] { 2, 4, 4, 0 });
        SetUpgrade2Info("Skill : Adrenaline");
    }

    protected override void SetUpgrade_Level2_Type2_Elite()
    {
        //아머 적 공격 가능
        canAttackArmor = true;

        SetUpgrade1Function(SetUpgrade_Level3_Type3);
        SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
        SetUpgrade1Info("Skill : One shot multiple kill");

        SetUpgrade2Function(SetUpgrade_Level3_Type4);
        SetUpgradePrice2(new int[] { 2, 4, 0, 4 });
        SetUpgrade2Info("Skill : Arrow bomb");
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

        SetSkill(Skill3, skill3CoolTime);
        isSkillReady = true;

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

    protected override void UpgradeAttack_Leve2_Tyep1()
    {
        float angle = LookTargetAngle();

        GameObject outbullet1 = OutPool();
        outbullet1.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, -30));
        outbullet1.transform.position = firePosition.position;

        GameObject outbullet2 = OutPool();
        outbullet2.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet2.transform.position = firePosition.position;

        GameObject outbullet3 = OutPool();
        outbullet3.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, 30));
        outbullet3.transform.position = firePosition.position;
    }

    //Skill
    protected override void Skill1()
    {
        float target_x = target.transform.position.x;
        float target_y = target.transform.position.y;

        GameObject skillObj = Instantiate(towersAllSkill[0], new Vector3(target_x, target_y, 0), Quaternion.identity);
        Attack_Parent skillObjScript = skillObj.GetComponent<Attack_Parent>();

        skillObjScript.SetMasterTower(this.gameObject);
        skillObjScript.SetDamage((int)(attackDamage * 1.5f), attackDamage + (int)(attackDamage * attackShieldDamageRate));
        skillObjScript.SetCanAttackFly(canAttackFly);
        skillObjScript.SetCanAttackArmor(canAttackArmor);
        skillObjScript.SetMaxAttackCount(8);
        skillObjScript.SetComboAttackCount(comboAttackCount);
        skillObjScript.StatusEffect(false, false, false, false, false);

    }

    protected override void Skill2()
    {
        StartCoroutine("Skill2_SpeedBuff");
    }
    IEnumerator Skill2_SpeedBuff()
    {
        anim.SetFloat("AttackSpeed", 5f);
        attackRate = attackRate - 0.5f;

        yield return new WaitForSeconds(3f);

        anim.SetFloat("AttackSpeed", 1f);
        attackRate = attackRate + 0.5f;
    }

    protected override void Skill3()
    {
        float angle = LookTargetAngle();

        GameObject skillObj = Instantiate(towersAllSkill[2], new Vector3(firePosition.position.x, firePosition.position.y, 0), Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Attack_Parent skillObjScript = skillObj.GetComponent<Attack_Parent>();

        skillObjScript.SetMasterTower(this.gameObject);
        skillObjScript.SetMaxAttackCount(5);
    }

    protected override void Skill4()
    {
        float angle = LookTargetAngle();

        GameObject skillObj = Instantiate(towersAllSkill[3], new Vector3(firePosition.position.x, firePosition.position.y, 0), Quaternion.AngleAxis(angle - 90, Vector3.forward));
        Attack_Parent skillObjScript = skillObj.GetComponent<Attack_Parent>();

        skillObjScript.SetMasterTower(this.gameObject);
        skillObjScript.SetDamage((int)(attackDamage * 3f), attackDamage + (int)(attackDamage * attackShieldDamageRate));
        skillObjScript.SetCanAttackFly(canAttackFly);
        skillObjScript.SetCanAttackArmor(canAttackArmor);
        skillObjScript.SetMaxAttackCount(8);
        skillObjScript.SetComboAttackCount(comboAttackCount);
        skillObjScript.StatusEffect(false, false, false, false, false);

    }
}
