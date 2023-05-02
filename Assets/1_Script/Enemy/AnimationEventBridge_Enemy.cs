using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventBridge_Enemy : MonoBehaviour
{
    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    public void ReturnPool()
    {
        enemy.ReturnPool();
    }
}
