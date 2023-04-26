using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMouseInteraction : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Camera myCamera;    

    void Update()
    {
        MouseClick();
    }

    void MouseClick()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 pos = myCamera.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f, LayerMask.GetMask("Tower"));

            if(hit.collider != null)
            {
                GameObject curTower = hit.transform.gameObject;
                gameManager.SetSelectTower(curTower);                
            }                
            else
            {
                gameManager.SelectCancel();
            }
        }
    }
}
