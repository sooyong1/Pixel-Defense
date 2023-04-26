using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyDelay = 3f;

    void Start()
    {
        StartCoroutine("DestoryCoroutine");
    }

    IEnumerator DestoryCoroutine()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }

}
