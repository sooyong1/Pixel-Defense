using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_Puppet : Tower
{

    /// upgrade
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
        //공격범위 증가, 데미지 증가
        AddAttackRange(0.3f);
        attackDamage += 30;        

        SetUpgrade1Function(SetUpgrade_Level1_Type1_Elite);
        SetUpgradePrice1(new int[] { 2, 0, 0, 2 });
        SetUpgrade1Info("Increase attack speed.");

        SetUpgrade2Function(null);        
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });        
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level1_Type1_Elite()
    {        
        //데미지 증가, 공중 공격 가능
        attackDamage += 15;
        canAttackFly = true;

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
        //기본공격 강화, 데미지 증가, 범위 증가
        SetCurrentAttackFunction(UpgradeAttack_Leve2_Tyep1);
        attackDamage += 50;
        AddAttackRange(0.3f);

        SetUpgrade1Function(SetUpgrade_Level2_Type1_Elite);        
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("12");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });        
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level2_Type2()
    {
        SetUpgrade1Function(SetUpgrade_Level2_Type2_Elite);        
        SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
        SetUpgrade1Info("elite");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }


    protected override void SetUpgrade_Level2_Type1_Elite()
    {
        SetUpgrade1Function(SetUpgrade_Level3_Type1);
        SetUpgradePrice1(new int[] { 2, 4, 4, 0 });
        SetUpgrade1Info("ty");

        SetUpgrade2Function(SetUpgrade_Level3_Type2);        
        SetUpgradePrice2(new int[] { 2, 4, 4, 0 });        
        SetUpgrade2Info("yt");
    }

    protected override void SetUpgrade_Level2_Type2_Elite()
    {
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
        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type2()
    {
        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type3()
    {
        SetUpgrade1Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");

        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade_Level3_Type4()
    {
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
        outbullet1.transform.position = transform.position;

        GameObject outbullet2 = OutPool();
        outbullet2.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet2.transform.position = transform.position;

        GameObject outbullet3 = OutPool();
        outbullet3.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, 30));
        outbullet3.transform.position = transform.position;
    }

}
