using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //jjang
    protected enum State { Search, Attack };
    
    public GameObject[] towersAllBullet;
    public GameObject arrangeSprite;
    public Transform firePosition;
    public float attackRange = 2f;
    public int attackDamage = 50;
    public float attackRate = 1f;
    public int attackShieldDamageRate = -1; // ¸¸¾à -1 => damage/2,  
    public float bulletLifeTime = 0.2f;
    public int maxAttackCount = 1;
    public int comboAttackCount = 1;

    protected int usingBulletType = 0;
    protected GameObject bullet;

    [Header("Specific Attack")]
    [SerializeField] protected bool canAttackFly = false;
    [SerializeField] protected bool canAttackArmor = false;

    [Header("Status Effect")]
    [SerializeField] protected bool isCold = false;
    [SerializeField] protected bool isBurn = false;
    [SerializeField] protected bool isChaos = false;
    [SerializeField] protected bool isStun = false;
    [SerializeField] protected bool isPushBack = false;

    protected GameObject target = null;
    protected Animator anim;
    protected EnemyManager enemyManager;

    [HideInInspector] public delegate void Callback();
    [HideInInspector] public Callback curAttackFunc = null;
    [HideInInspector] public Callback Upgrade1 = null;
    [HideInInspector] public Callback Upgrade2 = null;
    protected int[] upgrade1_Price = {0, 0, 0, 0};
    protected int[] upgrade2_Price = { 0, 0, 0, 0 };

    protected string upgrade1_Info = "";
    protected string upgrade2_Info = "";

    

    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        enemyManager = GameObject.FindWithTag("EnemyManager").GetComponent<EnemyManager>();
        bullet = towersAllBullet[usingBulletType];

        UpdateArrangeSpriteSize();
    }

    void Start()
    {
        StartCoroutine("SearchTarget");

        SetUpgradeInit();        
        SetCurrentAttackFunction(DefaultAttack);
    }   


    IEnumerator Attack()
    {        
        while(target != null && Vector3.Distance(transform.position, target.transform.position) <= attackRange && target.activeSelf)
        {            
            if(target.transform.position.x > transform.position.x) transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            else transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(attackRate);
        }
        
        target = null;
        ChangeState(State.Search);
    }

    IEnumerator SearchTarget()
    {        
        while (target == null)
        {
            yield return null;

            float minDis = 1000f;
            GameObject targetEnemy = null;

            foreach(GameObject temp in enemyManager.enemyInTrack)
            {
                bool canAttackFlyingEnemy = (temp.GetComponent<Enemy>().GetIsFly() && canAttackFly) || !temp.GetComponent<Enemy>().GetIsFly();
                
                float dis = Vector3.Distance(transform.position, temp.transform.position);
                if (minDis > dis && dis <= attackRange && canAttackFlyingEnemy)
                {
                    minDis = dis;
                    targetEnemy = temp;
                }
            }

            target = targetEnemy;
        }

        ChangeState(State.Attack);
    }


    void ChangeState(State changeState)
    {
        switch (changeState)
        {
            case State.Search:
                StopCoroutine("Attack");
                StartCoroutine("SearchTarget");
                break;

            case State.Attack:
                StopCoroutine("SearchTarget");
                StartCoroutine("Attack");
                break;
        }
    }

    public GameObject OutPool()
    {
        if (bulletPool.Count == 0) MakeBullet();

        GameObject outBullet = bulletPool.Dequeue();
        Bullet outBulletScript = outBullet.GetComponent<Bullet>();

        outBulletScript.SetLifeTime(bulletLifeTime);
        outBullet.SetActive(true);
        outBulletScript.SetMasterTower(this.gameObject);        
        outBulletScript.SetDamage(attackDamage, attackShieldDamageRate);
        outBulletScript.SetCanAttackFly(canAttackFly);
        outBulletScript.SetCanAttackArmor(canAttackArmor);
        outBulletScript.SetMaxAttackCount(maxAttackCount);
        outBulletScript.SetComboAttackCount(comboAttackCount);
        outBulletScript.StatusEffect(isCold, isBurn, isChaos, isStun, isPushBack);
        return outBullet;
    }

    public void InPool(GameObject obj)
    {
        bulletPool.Enqueue(obj);
    }

    public void MakeBullet()
    {
        GameObject makeBullet = Instantiate(bullet, new Vector3(100,200,0), Quaternion.identity);
        makeBullet.GetComponent<Bullet>().SetBulletType(usingBulletType);        
        bulletPool.Enqueue(makeBullet);

        makeBullet.SetActive(false);
    }    

    public void UpdateArrangeSpriteSize()
    {
        float newScale = attackRange / 0.5f;

        Transform parent = transform.parent;
        arrangeSprite.transform.parent = null;
        arrangeSprite.transform.localScale = new Vector3(newScale, newScale, newScale);
        arrangeSprite.transform.parent = parent;
    }
    public void SetArrangeSpriteOnOff(bool OnOff)
    {
        arrangeSprite.SetActive(OnOff);
    }

    public void AddAttackRange(float value)
    {
        attackRange += value;
        UpdateArrangeSpriteSize();
    }
    /// ===============
    public float LookTargetAngle()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        return angle;
    }


    public void SetUpgradePrice1(int[] newPrice)
    {
        upgrade1_Price = newPrice;
    }
    public void SetUpgradePrice2(int[] newPrice)
    {
        upgrade2_Price = newPrice;
    }
    public int[] GetUpgradePrice1()
    {
        return upgrade1_Price;
    }
    public int[] GetUpgradePrice2()
    {
        return upgrade2_Price;
    }
    public string GetUpgrade1Info()
    {
        return upgrade1_Info;
    }
    public string GetUpgrade2Info()
    {
        return upgrade2_Info;
    }
    public void SetUpgrade1Info(string inputInfo)
    {
        upgrade1_Info = inputInfo;
    }
    public void SetUpgrade2Info(string inputInfo)
    {
        upgrade2_Info = inputInfo;
    }
    public int GetUsingBulletType()
    {
        return usingBulletType;
    }
    public void SetUsingBulletType(int inputType)
    {
        usingBulletType = inputType;
        bullet = towersAllBullet[usingBulletType];
        
        while(bulletPool.Count != 0)
        {
            Destroy(bulletPool.Dequeue());
        }
    }

    public void Fire()
    {
        if (target == null)
        {            
            anim.SetTrigger("Stop");
            return;
        }

        curAttackFunc();
    }



    protected void SetCurrentAttackFunction(Callback cal)
    {
        curAttackFunc = cal;
    }
    protected void SetUpgrade1Function(Callback cal)
    {
        Upgrade1 = cal;        
    }
    protected void SetUpgrade2Function(Callback cal)
    {
        Upgrade2 = cal;        
    }

    protected virtual void SetUpgradeInit() { }

    protected virtual void SetUpgrade_Level1_Type1() { }
    protected virtual void SetUpgrade_Level1_Type1_Elite() { }
    //protected virtual void SetUpgrade1_2() { }

    protected virtual void SetUpgrade_Level2_Type1() { }
    protected virtual void SetUpgrade_Level2_Type2() { }

    protected virtual void SetUpgrade_Level2_Type1_Elite() { }
    protected virtual void SetUpgrade_Level2_Type2_Elite() { }

    protected virtual void SetUpgrade_Level3_Type1() { }
    protected virtual void SetUpgrade_Level3_Type2() { }
    protected virtual void SetUpgrade_Level3_Type3() { }
    protected virtual void SetUpgrade_Level3_Type4() { }



    protected virtual void DefaultAttack() { }

    protected virtual void UpgradeAttack_Level_Tyep1() { }    

    protected virtual void UpgradeAttack_Leve2_Tyep1() { }
    protected virtual void UpgradeAttack_Leve2_Tyep2() { }

    protected virtual void UpgradeAttack_Leve3_Tyep1() { }
    protected virtual void UpgradeAttack_Leve3_Tyep2() { }
    protected virtual void UpgradeAttack_Leve3_Tyep3() { }
    protected virtual void UpgradeAttack_Leve3_Tyep4() { }

}
