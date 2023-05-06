using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTest : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(MyFunc());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collision");
        }
    }

    IEnumerator MyFunc()
    {
        yield return null;
        gameObject.SetActive(false);
    }
}
