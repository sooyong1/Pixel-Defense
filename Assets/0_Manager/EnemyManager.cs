using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]  private GameManager gameManager;
    [SerializeField] EnemyData enemyData;    

    private Dictionary<int, Queue<GameObject>> enemyPool = new Dictionary<int, Queue<GameObject>>();
    [HideInInspector] public List<GameObject> enemyInTrack = new List<GameObject>();

    void Awake()
    {                      
        for(int i = 1; i <= enemyData.GetAllEnemyCount(); i++)
        {
            Queue<GameObject> tempQ = new Queue<GameObject>();
            enemyPool.Add(i, tempQ);
        }
    }

    public GameObject PoolOutEnemy(int enemyType)
    {        
        if (enemyPool[enemyType].Count == 0) 
        {            
            GameObject newEnemy = MakeNewEnemyObject(enemyType); 
        }

        GameObject outEnemy = enemyPool[enemyType].Dequeue();
        AddEnemyInTrack(outEnemy);

        return outEnemy;        
    }

    public void PoolInEnemy(GameObject inEnemy, int enemyID)
    {
        RemoveEnemyInTrack(inEnemy);
        enemyPool[enemyID].Enqueue(inEnemy);
    }
    
    void AddEnemyInTrack(GameObject outEnemy)
    {
        outEnemy.SetActive(true);
        outEnemy.GetComponent<Enemy>().SetInitialize();
        enemyInTrack.Add(outEnemy);
        SetIsEnemyInTrack(true);
    }

    void RemoveEnemyInTrack(GameObject outEnemy)    
    {
        enemyInTrack.Remove(outEnemy);        
        SetIsEnemyInTrack( !(enemyInTrack.Count == 0) );
    }
    
    public void UpdateEnemyInTrack()
    {
        for(int i = 0; i < enemyInTrack.Count; i++)
        {
            if (enemyInTrack[i].activeSelf == false)
            {
                enemyInTrack.RemoveAt(i);
            }
        }
        SetIsEnemyInTrack(!(enemyInTrack.Count == 0));
    }
    
    GameObject MakeNewEnemyObject(int enemyType)
    {        
        GameObject newEnemy = Instantiate(enemyData.GetEnemyPrefab(enemyType), new Vector3(100,100,0), Quaternion.identity);     
        
        newEnemy.GetComponent<Enemy>().SetEnemyID(enemyType);
        newEnemy.GetComponent<Enemy>().SetEnemyManager(this);
        newEnemy.GetComponent<Enemy>().SetGameManager(gameManager);
        enemyPool[enemyType].Enqueue(newEnemy);        
        newEnemy.SetActive(false);        

        return newEnemy;
    }

    void SetIsEnemyInTrack(bool flag)
    {        
        gameManager.SetIsEnemyInTrack(flag);
        if (!flag) gameManager.CheckFinishWave();
    }
    
}
