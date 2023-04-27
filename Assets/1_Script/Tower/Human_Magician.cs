using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human_Magician : Tower
{
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(SetUpgrade_Level1_Type1);
        SetUpgrade2Function(null);

        SetUpgradePrice1(new int[] { 2, 0, 0, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });

        SetUpgrade1Info("Doll Can Attack Flying Enemy.");
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
        //���ݹ��� ����, ������ ����
        AddAttackRange(0.3f);
        attackDamage += 20;

        SetUpgrade1Function(SetUpgrade_Level1_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Increase attack speed.");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level1_Type1_Elite()
    {
        //�ǵ� ���ݷ� ����, ���� ����
        attackShieldDamageRate += 0.5f;
        attackRate -= 0.2f;

        SetUpgrade1Function(SetUpgrade_Level2_Type1);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Increase attack speed.");

        SetUpgrade2Function(SetUpgrade_Level2_Type2);
        SetUpgradePrice2(new int[] { 0, 2, 0, 2 });
        SetUpgrade2Info("a");
    }

    /// Level 2
    protected override void SetUpgrade_Level2_Type1()
    {
        ChangeSkin(1);
        //����, �ִ� 5����, ������������� ��ȯ, ���� ����
        maxAttackCount = 5;
        SetUsingBulletType(1);
        SetCurrentAttackFunction(UpgradeAttack_Leve2_Tyep1);
        isCold = true;
        AddAttackRange(-0.5f);


        SetUpgrade1Function(SetUpgrade_Level2_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("12");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level2_Type2()
    {
        ChangeSkin(2);
        //�� ũ�� ����, ȭ��, ���ð��� 5, ���ݼӵ� ����
        isBurn = true;
        SetUsingBulletType(2);
        maxAttackCount = 5;
        attackRate += 0.5f;
        bulletLifeTime = 0.7f;

        SetUpgrade1Function(SetUpgrade_Level2_Type2_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
        SetUpgrade1Info("elite");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    protected override void SetUpgrade_Level2_Type1_Elite()
    {
        //���߰��� ����
        canAttackFly = true;

        SetUpgrade1Function(SetUpgrade_Level3_Type1);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("ty");

        SetUpgrade2Function(SetUpgrade_Level3_Type2);
        SetUpgradePrice2(new int[] { 2, 4, 4, 0 });
        SetUpgrade2Info("yt");
    }

    protected override void SetUpgrade_Level2_Type2_Elite()
    {
        //���߰��� ����
        canAttackFly = true;

        SetUpgrade1Function(SetUpgrade_Level3_Type3);
        SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
        SetUpgrade1Info("nw");

        SetUpgrade2Function(SetUpgrade_Level3_Type4);
        SetUpgradePrice2(new int[] { 2, 4, 0, 4 });
        SetUpgrade2Info("t,");
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
