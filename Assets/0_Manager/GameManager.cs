using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Spawner[] allSpawner;

    [SerializeField] private Button waveBtn;
    [SerializeField] private Button upgrade1Btn;
    [SerializeField] private Button upgrade2Btn;
    [SerializeField] private Button makeDollBtn;
    [SerializeField] private Button stoneWorkBtn;
    [SerializeField] private Button restartBtn;

    [SerializeField] private Inventory inventory;
    [SerializeField] private TowerManager towerManager;
    [SerializeField] private EnemyManager enemyManager;

    [SerializeField] private Text lifeTxt;
    [SerializeField] private Text waveTxt;
    [SerializeField] private int startLife = 50;
    private int curLife;
    public int waveCount = 0;

    private bool isSpawnerWorking = false;
    private bool isEnemyInTrack = false;

    private GameObject curSelectTower = null;
    private Tower curSelectTowerScript = null;
    private GameObject curArrangementTower = null;
    private int curSelectSlot;    

    [SerializeField] private int stone_White = 150;
    [SerializeField] private Text stone_White_txt;
    private int[] stone_Color = { 0, 0, 0, 0 }; //red green blue yellow
    [SerializeField] private Text[] stone_Color_txt;
    [SerializeField] private Text[] stone_Upgrade1Price_txt;
    [SerializeField] private Text[] stone_Upgrade2Price_txt;
    private int[] stone_Upgrade1Price = {0, 0, 0, 0};
    private int[] stone_Upgrade2Price = {0, 0, 0, 0};
    [SerializeField] private Text upgrade1_InfoTxt;
    [SerializeField] private Text upgrade2_InfoTxt;

    private int makeDollPrice = 30;
    private int makeColorStonePrice = 50;

    [SerializeField] private Text waveSpeed_txt;

    [SerializeField] private GameObject gameOverPanel;
    private bool isGameOver = false;

    void Awake()
    {
        curLife = startLife;
        
        UpdateWaveTxt();
        UpdateLifeTxt();
        UpdateStoneCountTxt_White();
        UpdateStoneCountTxt_Color();
        SetCurrentTowerUpgradePrice();
        SetUpgradeInfoText();
    }

    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Spawner");
        allSpawner = new Spawner[obj.Length];        

        for(int i = 0; i < allSpawner.Length; i++)
        {            
            allSpawner[i] = obj[i].GetComponent<Spawner>();
        }
    } 

    void FixedUpdate()
    {
        if(!isSpawnerWorking) enemyManager.UpdateEnemyInTrack();
    }

    public void StartWave()
    {        
        foreach(Spawner temp in allSpawner)
        {
            SetWaveStart();
            AddWave();
            temp.StartWave();            
        }
    }

    public void WaveButtonEnable(bool OnOff)
    {
        if (OnOff) waveBtn.interactable = true;
        else waveBtn.interactable = false;
    }

    public void CheckFinishWave()
    {
        bool setWaveBtnEnable = !isEnemyInTrack && !isSpawnerWorking;        
        WaveButtonEnable(setWaveBtnEnable);
    }

    void SetWaveStart()
    {
        isSpawnerWorking = true;
        isEnemyInTrack = true;
        WaveButtonEnable(false);
    }

    public void SetIsSpawnerWorking(bool flag)
    {
        isSpawnerWorking = flag;
    }

    public void SetIsEnemyInTrack(bool flag)
    {
        isEnemyInTrack = flag;
    }

    public void Upgrade1BtnClick()
    {
        if (curSelectTower == null) return;
        if (!CheckStoneEnough(1)) return;

        PayColorStone(1);
        curSelectTowerScript.Upgrade1();        
        SetUpgradeButtonEnable();

        UpdateStoneCountTxt_Color();
        SetCurrentTowerUpgradePrice();
        SetUpgradeInfoText();
    }

    public void Upgrade2BtnClick()
    {
        if (curSelectTower == null || curSelectTowerScript.Upgrade2 == null) return;
        if (!CheckStoneEnough(2)) return;

        PayColorStone(2);
        curSelectTowerScript.Upgrade2();
        SetUpgradeButtonEnable();

        SetCurrentTowerUpgradePrice();
        UpdateStoneCountTxt_Color();
        SetUpgradeInfoText();
    }

    bool CheckStoneEnough(int upgradeType)
    {
        if(upgradeType == 1)
        {
            for(int i = 0; i < stone_Upgrade1Price.Length; i++)
            {
                if(stone_Color[i] < stone_Upgrade1Price[i])
                {
                    return false;
                }
            }
        }
        else
        {
            for (int i = 0; i < stone_Upgrade2Price.Length; i++)
            {
                if (stone_Color[i] < stone_Upgrade2Price[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    void PayColorStone(int upgradeType)
    {
        if (upgradeType == 1)
        {
            for (int i = 0; i < stone_Upgrade1Price.Length; i++)
            {
                stone_Color[i] -= stone_Upgrade1Price[i];                
            }
        }
        else
        {
            for (int i = 0; i < stone_Upgrade2Price.Length; i++)
            {
                stone_Color[i] -= stone_Upgrade2Price[i];
            }
        }
    }    

    public void SetSelectTower(GameObject obj)
    {
        if (curArrangementTower != null) return;
        if(curSelectTower != null) curSelectTowerScript.SetArrangeSpriteOnOff(false);

        curSelectTower = obj;
        curSelectTowerScript = curSelectTower.GetComponent<Tower>();
        curSelectTowerScript.SetArrangeSpriteOnOff(true);
        SetUpgradeButtonEnable();
        SetCurrentTowerUpgradePrice();
        SetUpgradeInfoText();
    }
    
    void SetUpgradeButtonEnable()
    {
        if (curSelectTower == null) return;

        if (curSelectTowerScript.Upgrade1 == null) upgrade1Btn.interactable = false;
        else upgrade1Btn.interactable = true;

        if (curSelectTowerScript.Upgrade2 == null) upgrade2Btn.interactable = false;
        else upgrade2Btn.interactable = true;
    }

    void SetCurrentTowerUpgradePrice()
    {
        if (curSelectTower == null)
        {
            for (int i = 0; i < stone_Upgrade1Price_txt.Length; i++) stone_Upgrade1Price_txt[i].text = "";
            for (int i = 0; i < stone_Upgrade2Price_txt.Length; i++) stone_Upgrade2Price_txt[i].text = "";
            return;
        }

        stone_Upgrade1Price = curSelectTowerScript.GetUpgradePrice1();
        stone_Upgrade2Price = curSelectTowerScript.GetUpgradePrice2();

        for (int i = 0; i < stone_Upgrade1Price_txt.Length; i++) stone_Upgrade1Price_txt[i].text = stone_Upgrade1Price[i].ToString();
        for (int i = 0; i < stone_Upgrade2Price_txt.Length; i++) stone_Upgrade2Price_txt[i].text = stone_Upgrade2Price[i].ToString();
    }

    public void SelectCancel()
    {
        if (curSelectTower != null) curSelectTowerScript.SetArrangeSpriteOnOff(false);
        curSelectTower = null;
        upgrade1Btn.interactable = false;
        upgrade2Btn.interactable = false;

        PriceInit();
        SetUpgradeInfoText();
    }

    void PriceInit()
    {
        int[] temp = { 0, 0, 0, 0 };
        stone_Upgrade1Price = temp;
        stone_Upgrade2Price = temp;

        stone_Upgrade1Price_txt[0].text = "";
        stone_Upgrade1Price_txt[1].text = "";
        stone_Upgrade1Price_txt[2].text = "";
        stone_Upgrade1Price_txt[3].text = "";

        stone_Upgrade2Price_txt[0].text = "";
        stone_Upgrade2Price_txt[1].text = "";
        stone_Upgrade2Price_txt[2].text = "";
        stone_Upgrade2Price_txt[3].text = "";
    }

    public void SelectCancelBtnClick()
    {
        if(curSelectTower != null) curSelectTowerScript.SetArrangeSpriteOnOff(false);
        curSelectTower = null;
        upgrade1Btn.interactable = false;
        upgrade2Btn.interactable = false;
        CancelArrangement();
        SetUpgradeInfoText();
    }

    public void MakeDollBtnClick()
    {
        if (stone_White < makeDollPrice) return;
        if(inventory.GetCurrentTowerCount() == inventory.GetMaxTowerCount())
        {            
            return;
        }

        stone_White -= makeDollPrice;
        UpdateStoneCountTxt_White();

        int randomTower = Random.Range(1,towerManager.GetSize());
        inventory.AddTower(randomTower);
    }

    public void AddStone_White(int value)
    {
        stone_White += value + (waveCount/2);
        UpdateStoneCountTxt_White();
    }

    public void StoneWorkBtnClick()
    {
        if (stone_White < makeColorStonePrice) return;

        stone_White -= makeColorStonePrice;        
        AddRandomColorStone();

        UpdateStoneCountTxt_White();
    }

    void AddRandomColorStone()
    {
        int rand = Random.Range(0, stone_Color.Length);
        stone_Color[rand]++;
        UpdateStoneCountTxt_Color();
    }

    public void UpdateStoneCountTxt_White()
    {
        stone_White_txt.text = "x" + stone_White.ToString();
    }

    public void UpdateStoneCountTxt_Color()
    {
        for(int i = 0; i < stone_Color_txt.Length; i++)
        {
            stone_Color_txt[i].text = "x" + stone_Color[i].ToString();
        }        
    }

    public void SetUpgradeInfoText()
    {
        if(curSelectTower == null)
        {
            upgrade1_InfoTxt.text = "";
            upgrade2_InfoTxt.text = "";
            return;
        }

        upgrade1_InfoTxt.text = curSelectTowerScript.GetUpgrade1Info();
        upgrade2_InfoTxt.text = curSelectTowerScript.GetUpgrade2Info();
    }

    
    public void AddLife(int value = 1)
    {
        curLife += value;
        UpdateLifeTxt();
    }
    public void MinusLife(int value = 1)
    {
        if (curLife == 0) return;
        curLife -= value;
        UpdateLifeTxt();

        if (curLife == 0) SetGameOver();
    }
    public void AddWave()
    {
        waveCount++;
        UpdateWaveTxt();
    }
    public void UpdateWaveTxt()
    {
        waveTxt.text = waveCount.ToString();
    }
    public void UpdateLifeTxt()
    {
        lifeTxt.text = curLife.ToString();
    }

    void SetGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //====================== 타워 배치관련

    public void SetTowerArrangement(int towerNum, int slotIndex)
    {
        CancelArrangement();

        SelectCancel();
        GameObject temp = Instantiate( towerManager.towerData[towerNum].Arrangement, new Vector3(100,100,0), Quaternion.identity);
        temp.GetComponent<TowerArrangement>().SetTowerID(towerNum);
        temp.GetComponent<TowerArrangement>().SetGameManager(this);
        curArrangementTower = temp;
        curSelectSlot = slotIndex;        
    }

    public void CancelArrangement()
    {
        if (curArrangementTower != null)
        {
            Destroy(curArrangementTower);
            curArrangementTower = null;
            curSelectSlot = 0;
        }
    }

    public void BuildTower()
    {
        Instantiate(towerManager.towerData[curArrangementTower.GetComponent<TowerArrangement>().GetTowerID()].TowerPrefab, curArrangementTower.transform.position, Quaternion.identity);        
        inventory.RemoveTower(curSelectSlot);
        CancelArrangement();
    }

    //======================

    public void ToggleGameSpeed()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 2f;
            waveSpeed_txt.text = "X " + 2.ToString();
        }
        else if (Time.timeScale == 2f)
        {
            Time.timeScale = 3f;
            waveSpeed_txt.text = "X " + 3.ToString();
        }
        else
        {
            Time.timeScale = 1f;
            waveSpeed_txt.text = "X " + 1.ToString();
        }
    }
    
}
