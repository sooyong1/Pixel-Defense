using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    private int towerNum = 0;
    [SerializeField] private Button slotBtn;
    private TowerManager towerManager;
    private GameManager gameManager;
    private int slotIndex = 0;

    void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        towerManager = GameObject.FindWithTag("TowerManager").GetComponent<TowerManager>();
    }

    public void SetSlot(int getTowerNum)
    {
        towerNum = getTowerNum;
        
        if (towerNum == 0) ButtonEnable(false);
        else ButtonEnable(true);

        slotBtn.GetComponent<Image>().sprite = towerManager.towerData[getTowerNum].InventoryImage;
    }

    public void ButtonEnable(bool OnOff)
    {
        slotBtn.interactable = OnOff;
    }

    public int GetTowerNum()
    {
        return towerNum;
    }

    public void SlotBtnClick()
    {
        if (towerNum == 0) return;
        gameManager.SetTowerArrangement(towerNum, slotIndex);
    }

    public void SetSlotIndex(int index)
    {
        slotIndex = index;
    }

}
