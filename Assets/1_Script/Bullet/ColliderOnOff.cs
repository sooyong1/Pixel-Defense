using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOnOff : MonoBehaviour
{
    [SerializeField] Collider2D col;
    [SerializeField] bool colliderOnOff = false;    

    [SerializeField] bool useTimer = true;
    [SerializeField] float switchTimer = 1f;

    [SerializeField] bool useFrame = false;
    [SerializeField] int frameCount = 1;

    private void Awake()
    {
        if (useTimer && useFrame) useFrame = false;
    }

    private void Start()
    {
        if (useTimer) StartCoroutine("TimerWork");
        else if (useFrame) StartCoroutine("FrameWork");

    }

    IEnumerator TimerWork()
    {
        yield return new WaitForSeconds(switchTimer);
        col.enabled = colliderOnOff;
    }

    IEnumerator FrameWork()
    {
        int count = 0;
        
        while(count < frameCount)
        {
            yield return null;
            count++;
        }        
        
        col.enabled = colliderOnOff;

        Debug.Log("here");
    }

}
