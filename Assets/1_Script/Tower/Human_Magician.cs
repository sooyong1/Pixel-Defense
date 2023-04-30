using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Magician : Tower
{
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(SetUpgrade_Level1_Type1);
        SetUpgrade2Function(null);

        SetUpgradePrice1(new int[] { 0, 0, 2, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });

        SetUpgrade1Info("Increase attack range.");
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
        SetUpgradePrice1(new int[] { 0, 0, 2, 2 });
        SetUpgrade1Info("Increase shield damage.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level1_Type1_Elite()
    {
        //실드 공격력 증가, 공속 증가
        attackShieldDamageRate += 0.5f;
        AddAttackRate(-0.2f);
        attackDamage += 30;

        SetUpgrade1Function(SetUpgrade_Level2_Type1);
        SetUpgradePrice1(new int[] { 1, 1, 4, 0 });
        SetUpgrade1Info("Magician freezes the surroundings.");

        SetUpgrade2Function(SetUpgrade_Level2_Type2);
        SetUpgradePrice2(new int[] { 0, 1, 4, 1 });
        SetUpgrade2Info("Magician make fire ball.");
    }

    /// Level 2
    protected override void SetUpgrade_Level2_Type1()
    {
        ChangeSkin(1);
        //빙결, 최대 5마리, 방사형공격으로 변환, 범위 감소
        maxAttackCount = 5;
        SetUsingBulletType(1);
        SetCurrentAttackFunction(UpgradeAttack_Leve2_Tyep1);
        isCold = true;
        AddAttackRange(-0.5f);
        attackDamage += 40;


        SetUpgrade1Function(SetUpgrade_Level2_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("Magician can attack flying enemies.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level2_Type2()
    {
        ChangeSkin(2);
        //공 크기 증가, 화상, 동시공격 5, 공격속도 감소
        isBurn = true;
        SetUsingBulletType(2);
        maxAttackCount = 5;
        AddAttackRate(0.5f);
        bulletLifeTime = 0.7f;
        attackDamage += 50;

        SetUpgrade1Function(SetUpgrade_Level2_Type2_Elite);
        SetUpgradePrice1(new int[] { 2, 2, 4, 2 });
        SetUpgrade1Info("Magician can attack flying enemies.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    protected override void SetUpgrade_Level2_Type1_Elite()
    {
        //공중공격 가능
        canAttackFly = true;
        attackDamage += 60;

        SetUpgrade1Function(SetUpgrade_Level3_Type1);
        SetUpgradePrice1(new int[] { 4, 0, 6, 6 });
        SetUpgrade1Info("Skill : ");

        SetUpgrade2Function(SetUpgrade_Level3_Type2);
        SetUpgradePrice2(new int[] { 0, 6, 6, 4 });
        SetUpgrade2Info("Skill :");
    }

    protected override void SetUpgrade_Level2_Type2_Elite()
    {
        //공중공격 가능
        canAttackFly = true;
        attackDamage += 60;

        SetUpgrade1Function(SetUpgrade_Level3_Type3);
        SetUpgradePrice1(new int[] { 6, 2, 6, 2 });
        SetUpgrade1Info("Skill :");

        SetUpgrade2Function(SetUpgrade_Level3_Type4);
        SetUpgradePrice2(new int[] { 3, 3, 6, 4 });
        SetUpgrade2Info("Skill :");
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

    //Attack Upgrade

    protected override void UpgradeAttack_Leve2_Tyep1() 
    {
        GameObject outbullet = OutPool();
        outbullet.transform.position = transform.root.position;

    }



    //Skill
    protected override void Skill1()
    {


    }

    protected override void Skill2()
    {
        
    }


    protected override void Skill3()
    {

    }

    protected override void Skill4()
    {


    }
}
