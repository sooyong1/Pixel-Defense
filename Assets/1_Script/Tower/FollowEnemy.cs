using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    private enum State { Search, Follow };
    private State state = State.Search;

    public float searchRange = 2f;
    public float moveSpeed = 1f;
    [SerializeField] protected bool canAttackFly = false;    

    private GameObject target = null;
    private WaitForSeconds coroutineSearchRate = new WaitForSeconds(0.05f);
    private EnemyManager enemyManager;
    private Vector3 startPosition;

    void Awake()
    {                
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        startPosition = transform.position;
    }
    private void Start()
    {
        StartCoroutine("SearchTarget");
    }

    private void Update()
    {
        if(IsActiveTarget())
        {
            Vector3 dir = (target.transform.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;            
        }
        else if(state == State.Follow)
        {
            state = State.Search;
            StopCoroutine("SearchTarget");
            StartCoroutine("SearchTarget");
        }
        else if(state == State.Search)
        {
            Vector3 dir = (startPosition - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
    }

    IEnumerator SearchTarget()
    {
        while (!IsActiveTarget())
        {
            yield return coroutineSearchRate;

            float minDis = 1000f;
            GameObject targetEnemy = null;

            foreach (GameObject temp in enemyManager.enemyInTrack)
            {
                Enemy tempEnemy = temp.GetComponent<Enemy>();
                bool canAttackFlyingEnemy = (tempEnemy.GetIsFly() && canAttackFly) || !tempEnemy.GetIsFly();

                float dis = Vector3.Distance(transform.position, temp.transform.position);
                if (minDis > dis && dis <= searchRange && canAttackFlyingEnemy && !tempEnemy.GetIsDead())
                {
                    minDis = dis;
                    targetEnemy = temp;
                }
            }

            target = targetEnemy;
            state = State.Follow;
        }        
    }           
    
    public bool IsActiveTarget()
    {
        return (target != null && target.activeSelf);
    }
}
