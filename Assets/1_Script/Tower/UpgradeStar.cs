using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeStar : MonoBehaviour
{
    [SerializeField] private GameObject[] StarGroup;
    [SerializeField] private int curStarIndex = 0;

    public void UpgradeTower()
    {
        StarGroup[curStarIndex].SetActive(false);
        if(StarGroup.Length-1 > curStarIndex) curStarIndex++;
        StarGroup[curStarIndex].SetActive(true);
    }
}
