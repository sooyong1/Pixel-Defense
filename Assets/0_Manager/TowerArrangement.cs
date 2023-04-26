using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerArrangement : MonoBehaviour
{
    [SerializeField] private GameObject arrangeSprite;
    [SerializeField] private float attackRange = 0f;
    private GameManager gameManager;
    private Vector2 MousePosition;
    private Camera myCamera;
    private int towerID = 0;

    private int CollisionTowerCount = 0;    

    void Awake()
    {
        myCamera = Camera.main;
        UpdateArrangeSpriteSize();
    }

    void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = myCamera.ScreenToWorldPoint(MousePosition);
        transform.position = MousePosition;

        BuildTower();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Tower"))
        {
            CollisionTowerCount++;
        }        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            CollisionTowerCount--;
        }        
    }
   

    void BuildTower()
    {        
        if (CollisionTowerCount != 0) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            gameManager.BuildTower();
        }
    }

    public void SetTowerID(int inputTowerID)
    {
        towerID = inputTowerID;
    }

    public int GetTowerID()
    {
        return towerID;
    }

    public void SetGameManager(GameManager input)
    {
        gameManager = input;
    }

    public void UpdateArrangeSpriteSize()
    {
        float newScale = attackRange / 0.5f;

        arrangeSprite.transform.localScale = new Vector3(newScale, newScale, newScale);
        /*
        Transform parent = transform.parent;
        arrangeSprite.transform.parent = null;
        arrangeSprite.transform.localScale = new Vector3(newScale, newScale, newScale);
        arrangeSprite.transform.parent = parent;
        arrangeSprite.transform.position = parent.position;
        */
    }
}
