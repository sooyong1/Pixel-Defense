using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject effectObj;

    public void objectOff()
    {
        effectObj.SetActive(false);
    }


}
