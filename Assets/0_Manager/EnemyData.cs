using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyData : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPrefab;

    public GameObject GetEnemyPrefab(int enemyType)
    {
        return EnemyPrefab[enemyType];
    }

    public int GetAllEnemyCount()
    {
        return EnemyPrefab.Length;
    }
}
