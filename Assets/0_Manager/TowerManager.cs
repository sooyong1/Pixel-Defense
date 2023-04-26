using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable] //Serializable을 사용해야 구조체 리스트를 만들 수 있음. using System을 꼭 해야함
public struct TowerData
{
    public GameObject TowerPrefab;
    public GameObject Arrangement;
    public Sprite InventoryImage;
    public bool isUnlock;
}

public class TowerManager : MonoBehaviour
{
    public TowerData[] towerData;

    public int GetSize()
    {
        return towerData.Length;
    }
}
