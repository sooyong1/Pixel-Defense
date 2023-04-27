using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBridge : MonoBehaviour
{
    Tower tower;

    private void Awake()
    {
        tower = GetComponentInParent<Tower>();
    }

    public void Fire()
    {
        tower.Fire();
    }

    public void CheckLostTarget()
    {
        tower.CheckLostTarget();
    }
}
