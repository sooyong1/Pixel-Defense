using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable] //Serializable�� ����ؾ� ����ü ����Ʈ�� ���� �� ����. using System�� �� �ؾ���
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
