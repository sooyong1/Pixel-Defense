using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public Transform hpBarTran;

    public void SetHpBarRate(float value)
    {
        Vector3 newScale = new Vector3(value, hpBarTran.localScale.y, hpBarTran.localScale.z);

        hpBarTran.localScale = newScale;
    }
}
