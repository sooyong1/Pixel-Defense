using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float speed = 15f;
    public bool isActive = true;

    void Update()
    {
        if (!isActive) return;

        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
