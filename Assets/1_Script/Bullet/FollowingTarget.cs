using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingTarget : MonoBehaviour
{
    [HideInInspector] public GameObject target = null;
    public float InitSpeed = 1;
    public float accelSpeed = 1;
    public float limitSpeed = 5;

    private float curSpeed = 0;
    private Vector3 curVector;


    private void Start()
    {
        SetVectorRandom();
    }

    private void Update()
    {
        if (target != null && target.activeSelf)
        {
            Vector3 targetDir = (target.transform.position - transform.position).normalized;
            curVector = curVector + (targetDir * curSpeed);
        }        

        transform.position += curVector* Time.deltaTime;

        if (curSpeed < limitSpeed) curSpeed += accelSpeed * Time.deltaTime;
    }

    public void SetTarget(GameObject inputTarget)
    {
        target = inputTarget;
    }

    public void SetVectorRandom()
    {
        float rand_x = Random.Range(InitSpeed * -1, InitSpeed);
        float rand_y = Random.Range(InitSpeed * -1, InitSpeed);

        curVector.x = rand_x;
        curVector.y = rand_y;
        curVector.z = 0;        
    }

}
