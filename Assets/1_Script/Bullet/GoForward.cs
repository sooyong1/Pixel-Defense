using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float speed = 15f;
    
    void Update()
    {        
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
