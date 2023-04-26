using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_Sniper : Tower
{
    /// upgrade
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(null);
        SetUpgrade2Function(null);

        SetUpgradePrice1(new int[] { 0, 0, 0, 2 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });

        SetUpgrade1Info("Increase attack speed.");
        SetUpgrade2Info("");
    }

    protected override void DefaultAttack()
    {
        float angle = LookTargetAngle();

        GameObject outbullet = OutPool();
        outbullet.transform.position = transform.position;
        outbullet.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet.GetComponent<Bullet>().EnemyDamage(target.GetComponent<Enemy>());
    }

    /// upgrade1
    /*

       protected override void SetUpgrade1_1()
       {
           attackRate -= 0.5f;

           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }

       /// upgrade2
       protected override void SetUpgrade2_1()
       {
           canAttackFly = true;
           attackRate = 0.5f;

           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }

       protected override void SetUpgrade2_2()
       {
           attackShieldDamage = attackDamage;
           maxAttackCount = 3;

           SetUpgrade1Function(SetUpgrade3_3);
           SetUpgrade2Function(SetUpgrade3_4);
           SetUpgradePrice1(new int[] { 2, 0, 4, 4 });
           SetUpgradePrice2(new int[] { 2, 4, 0, 4 });
           SetUpgrade1Info("Change to bullet bigger. \n Doll can attack 10 enemies.");
           SetUpgrade2Info("Change to bullet stronger. \nDoll can attack 5 enemies.");
       }


       /// upgrade3


       protected override void SetUpgrade3_1()
       {


           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }

       protected override void SetUpgrade3_2()
       {


           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }

       protected override void SetUpgrade3_3()
       {
           SetUsingBulletType(1);
           maxAttackCount = 10;

           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }

       protected override void SetUpgrade3_4()
       {
           maxAttackCount = 5;
           canAttackArmor = true;

           SetUpgrade1Function(null);
           SetUpgrade2Function(null);
           SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
           SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
           SetUpgrade1Info("");
           SetUpgrade2Info("");
       }
    */


    /// attack method

    




}
