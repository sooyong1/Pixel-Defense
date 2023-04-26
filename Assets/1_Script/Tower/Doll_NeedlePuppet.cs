using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll_NeedlePuppet : Tower
{
    /// upgrade
    protected override void SetUpgradeInit()
    {
        SetUpgrade1Function(null);        
        SetUpgradePrice1(new int[] { 0, 2, 0, 0 });
        SetUpgrade1Info("Increase Damage.");


        SetUpgrade2Function(null);
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade2Info("");
    }

    protected override void DefaultAttack()
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

    /// upgrad1
    /*

    protected override void SetUpgrade1_1()
    {
        attackDamage += 30;        
        
        SetUpgrade1Function(SetUpgrade2_1);
        SetUpgrade2Function(SetUpgrade2_2);

        SetUpgradePrice1(new int[] { 0, 2, 3, 0 });
        SetUpgradePrice2(new int[] { 0, 2, 0, 3 });

        SetUpgrade1Info("Shot five needles.");
        SetUpgrade2Info("Shot straight three needles.");
    }

    /// upgrad2

    protected override void SetUpgrade2_1()
    {
        SetCurrentAttackFunction(Upgrade2_1_Attack);

        SetUpgrade1Function(null);
        SetUpgrade2Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");
        SetUpgrade2Info("");
    }

    protected override void SetUpgrade2_2()
    {
        SetCurrentAttackFunction(Upgrade2_2_Attack);

        SetUpgrade1Function(null);
        SetUpgrade2Function(null);
        SetUpgradePrice1(new int[] { 0, 0, 0, 0 });
        SetUpgradePrice2(new int[] { 0, 0, 0, 0 });
        SetUpgrade1Info("");
        SetUpgrade2Info("");
    }






    /// attack method


    
    
    /// upgrade 1


    /// upgrade 2

    protected override void Upgrade2_1_Attack()
    {
        float angle = LookTargetAngle();

        GameObject outbullet1 = OutPool();
        outbullet1.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, -40));
        outbullet1.transform.position = transform.position;

        GameObject outbullet2 = OutPool();
        outbullet2.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, -20));
        outbullet2.transform.position = transform.position;

        GameObject outbullet3 = OutPool();
        outbullet3.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet3.transform.position = transform.position;

        GameObject outbullet4 = OutPool();
        outbullet4.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, 20));
        outbullet4.transform.position = transform.position;

        GameObject outbullet5 = OutPool();
        outbullet5.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward) * Quaternion.Euler(new Vector3(0, 0, 40));
        outbullet5.transform.position = transform.position;

    }

    protected override void Upgrade2_2_Attack()
    {
        float angle = LookTargetAngle();

        GameObject outbullet1 = OutPool();
        outbullet1.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet1.transform.position = transform.position - (outbullet1.transform.right * 0.1f);

        GameObject outbullet2 = OutPool();
        outbullet2.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet2.transform.position = transform.position;

        GameObject outbullet3 = OutPool();
        outbullet3.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        outbullet3.transform.position = transform.position + (outbullet1.transform.right * 0.1f);
    }

    */
    /// upgrade 3
}
