using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private ItemSlot[] itemSlots;
    [SerializeField] private GameManager gameManager;
    private int curTowerCount = 0;

    void Awake()
    {
        itemSlots = GetComponentsInChildren<ItemSlot>();

        for(int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].SetSlotIndex(i);
        }
    }

    public void AddTower(int towerNum)
    {
        for(int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i].GetTowerNum() == 0)
            {
                itemSlots[i].SetSlot(towerNum);
                curTowerCount++;
                break;
            }            
        }
    }

    public void RemoveTower(int slotIndex)
    {        
        itemSlots[slotIndex].SetSlot(0);
        curTowerCount--;

        SortInventory();
    }

    public void SortInventory()
    {
        for (int i = 0; i < itemSlots.Length-1; i++)
        {
            if (itemSlots[i].GetTowerNum() == 0)
            {
                itemSlots[i].SetSlot(itemSlots[i+1].GetTowerNum());
                itemSlots[i + 1].SetSlot(0);
            }
        }
    }

    public int GetCurrentTowerCount()
    {
        return curTowerCount;
    }

    public int GetMaxTowerCount()
    {
        return itemSlots.Length;
    }
}
