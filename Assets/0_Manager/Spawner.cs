using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

[Serializable] //Serializable을 사용해야 구조체 리스트를 만들 수 있음. using System을 꼭 해야함
public struct WaveData
{
    public int enemyID;
    public int spawnCount;
    public float spawnSpeed;
}

[Serializable] //Serializable을 사용해야 구조체 리스트를 만들 수 있음. using System을 꼭 해야함
public struct Wave
{
    public WaveData[] waveData;
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CinemachinePathBase m_Path;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private Wave[] wave;
    private int curWave = 0;    

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    public bool StartWave()
    {
        if (gameManager.GetIsGameOver()) return false;
        if (wave.Length <= curWave) return false;        

        StartCoroutine("RunWave");
        return true;
    }

    IEnumerator RunWave()
    {
        int curGroup = 0;        

        while (curGroup < wave[curWave].waveData.Length)
        {
            int spawnEnemyID = wave[curWave].waveData[curGroup].enemyID;
            int count = wave[curWave].waveData[curGroup].spawnCount;
            float spawnSpeed = wave[curWave].waveData[curGroup].spawnSpeed;

            while (count != 0)
            {
                yield return new WaitForSeconds(spawnSpeed);
                SpawnEnemy(spawnEnemyID);
                count--;
            }
            curGroup++;
        }

        FinishSpawn();

        curWave++;
    }

    void SpawnEnemy(int inputEnemyID)
    {
        GameObject newEnemy = enemyManager.PoolOutEnemy(inputEnemyID);
        newEnemy.GetComponent<Enemy>().SetPath(m_Path);        
    }

    void FinishSpawn()
    {        
        gameManager.SetIsSpawnerWorking(false);
        gameManager.CheckFinishWave();
    }
}
