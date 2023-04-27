using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUp : MonoBehaviour
{
    public float speed = 0.1f;
    public bool isActive = true;

    void Update()
    {
        if (!isActive) return;

        transform.localScale = new Vector3(transform.localScale.x + 1f * speed * Time.deltaTime, transform.localScale.y + 1f * speed * Time.deltaTime, 0);
    }
}
