using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public ReviseCartCode cart;
    public int maxHp = 150;
    public int maxShield = 0;
    public int giveStone_White = 8;

    [Header("Specific")]
    public bool isFly = false;      // 특정 타워는 얘를 공격 못함
    public bool isArmor = false;    // 특정 타워는 얘를 공격 못함
    public bool isHard = false;

    private GameManager gameManager;
    private int curHp;
    private int curShield;
    [Header(" ")]
    [SerializeField] private HpBar hpBar;
    [SerializeField] private HpBar shieldBar;
    [SerializeField] private GameObject shieldBarObj;
    private Spawner spawner;
    private bool isDead = false;
    private int enemyID = 1;
    private EnemyManager enemyManager;

    //private bool isCold = false;
    //private bool isBurn = false;
    //private bool isStun = false;
    //private bool isChaos = false;

    void Awake()
    {
        cart = GetComponent<ReviseCartCode>();
        curHp = maxHp;
        curShield = maxShield;
        ShieldOnOff();
    }

    void OnDisable()
    {
        curHp = maxHp;
        curShield = maxShield;
        hpBar.SetHpBarRate(1);
        shieldBar.SetHpBarRate(1);
        ShieldOnOff();        
    }

    public void SetInitialize()
    {
        curHp = maxHp;
        curShield = maxShield;
        hpBar.SetHpBarRate(1);
        shieldBar.SetHpBarRate(1);
        ShieldOnOff();

        cart.m_Position = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinishPortal"))
        {
            gameManager.MinusLife();
            ReturnPool();
        }
    }

    public void SetSpawner(Spawner getSpawner)
    {
        spawner = getSpawner;
    }



    IEnumerator DamageCoroutine(int inputDamage, int comboAttackCount = 1, float damageDecreaseRate = 1f)
    {
        int curCount = 0;
        int curDamage = inputDamage;

        while (curCount < comboAttackCount)
        {
            if (curShield > 0)
            {
                curShield -= curDamage;
                shieldBar.SetHpBarRate((float)curShield / maxShield);
                if (curShield <= 0)
                {
                    curShield = 0;
                    shieldBarObj.SetActive(false);
                }

            }
            else
            {
                if (isHard == true) curHp -= 1;
                else curHp -= curDamage;

                hpBar.SetHpBarRate((float)curHp / maxHp);

                if (curHp <= 0)
                {
                    isDead = true;
                    GiveStone();
                    ReturnPool();
                }
            }

            curDamage = (int)(curDamage * damageDecreaseRate);
            curCount++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void Damage(int damage, int comboAttackCount = 1, float damageDecreaseRate = 1)
    {
        StartCoroutine(DamageCoroutine(damage, comboAttackCount, damageDecreaseRate));
    }

    public void StatusEffect(bool inputIsCold, bool inputIsBurn, bool inputIsChaos, bool inputIsStun, bool inputIsPushBack)
    {
        if (!this.gameObject.activeSelf) return;

        if(inputIsCold)
        {
            StopCoroutine("DamageCold");
            StartCoroutine("DamageCold");
        }

        if(inputIsBurn)
        {
            StopCoroutine("DamageBurn");
            StartCoroutine("DamageBurn");
        }

        if (inputIsChaos)
        {
            StopCoroutine("DamageChaos");
            StartCoroutine("DamageChaos");
        }

        if (inputIsStun)
        {
            StopCoroutine("DamageStun");
            StartCoroutine("DamageStun");
        }

        if (inputIsPushBack)
        {
            PushAttack();
        }

    }
   

    public void ShieldOnOff()
    {
        shieldBarObj.SetActive(curShield > 0);
    }

    public void ReturnPool()
    {
        StopAllCoroutines();
        enemyManager.PoolInEnemy(this.gameObject, enemyID);
        transform.position = new Vector3(100, 100, 0);        
        ResetStatusEffect();
        this.gameObject.SetActive(false);
    }

    void ResetStatusEffect()
    {
        //isCold = false;
        //isBurn = false;
        //isChaos = false;
        //isStun = false;
        cart.ResetCart();
    }

    public void PushAttack()
    {
        cart.PushBack();
    }

    IEnumerator DamageCold()
    {        
        cart.m_Speed = cart.originalSpeed/2;
        yield return new WaitForSeconds(5f);
        cart.m_Speed = cart.originalSpeed;        
    }
    IEnumerator DamageBurn()
    {        
        int burnCount = 10;

        while(burnCount != 0)
        {
            Damage((int)(maxHp * 0.03f));
            yield return new WaitForSeconds(1f);
            burnCount--;
        }                        
    }
    IEnumerator DamageChaos()
    {        
        cart.m_Speed = -1 * Mathf.Abs(cart.m_Speed);
        yield return new WaitForSeconds(1.5f);
        cart.m_Speed = Mathf.Abs(cart.m_Speed);        
    }
    IEnumerator DamageStun()
    {        
        cart.isStun = true;
        yield return new WaitForSeconds(1f);        
        cart.isStun = false;
    }


    public bool GetIsDead()
    {
        return isDead;
    }
    public bool GetIsHaveShield()
    {
        return curShield > 0;
    }
    public void SetEnemyID(int inputID)
    {
        enemyID = inputID;
    }
    public void SetPath(CinemachinePathBase myPath)
    {
        cart.SetPath(myPath);
    }
    public void SetEnemyManager(EnemyManager inputManager)
    {
        enemyManager = inputManager;
    }
    public void SetGameManager(GameManager inputManager)
    {
        gameManager = inputManager;
    }
    public void GiveStone()
    {
        gameManager.AddStone_White(giveStone_White);
    }
    public bool GetIsFly()
    {
        return isFly;
    }
    public bool GetIsArmor()
    {
        return isArmor;
    }
}
