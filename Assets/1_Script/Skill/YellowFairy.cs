using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFairy : Tower
{
    protected override void DefaultAttack()
    {
        GameObject outbullet = OutPool();
        outbullet.transform.position = transform.root.position;
    }
}
