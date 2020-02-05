using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Player : MonoBehaviour
{
    public float attackMod;
    public float maxHp;
    public float currHp;
    public bool isDead = false;
    public bool attacked;
    public Camera mainCamera;
    public Vector3 mousePos;
    public SimpleHealthBar attackBar;
    public SimpleHealthBar healthBar;
    public Text gameOverText;
    public GameObject map;
    //public GameObject enemy;


    AIPath aIPath;
    Spear spear;
    //Shield shield;
    
    MiniMapClicker miniMapClicker;
    RaycastHit hit;
    PlayerController  playerController;
   

    float canTapTimer = 0.5f;
    float canAttackTimer = 1.5f;
    public float maxAttackValue = 1.5f;
    bool canTap = true;



    private void Start()
    {
        
        spear = GetComponentInChildren<Spear>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
        //shield = GetComponentInChildren<Shield>();
        miniMapClicker = FindObjectOfType<MiniMapClicker>();
        aIPath.canMove = false;
        playerController = FindObjectOfType<PlayerController>();
    }

    public void SetDMG(float dmg)
    {
        //if (!shield.shielded)
        {
            currHp -= dmg;
            healthBar.UpdateBar(currHp,maxHp);
            if (currHp <= 0)
            {
                isDead = true;
                gameOverText.text = "GameOver";
                gameOverText.gameObject.SetActive(true);
            }
        }


    }
    public bool Dodge()
    {
        float chance = 50;
        if (chance >= Random.Range(0f, 100f) && playerController.canAttack)
        {
            spear.GetComponentInChildren<Animator>().Play("Dodge");
            return true;
        }
        else
        {
            
            return false;
        }
    }

    void AttackBar()
    {
        if (!attacked)
        {
            canAttackTimer -= Time.deltaTime;
            attackMod += Time.deltaTime;
            attackBar.UpdateBar(attackMod, maxAttackValue);

            if (attackMod >= maxAttackValue)
            {
                attackMod = maxAttackValue;
                attackBar.colorMode = SimpleHealthBar.ColorMode.Single;
                attackBar.UpdateColor(Color.yellow);
            }
        }
        if (attacked)
        {
            canAttackTimer = maxAttackValue;
            attacked = false;
            attackMod = 0;
            attackBar.colorMode = SimpleHealthBar.ColorMode.Gradient;
        }
    }

    void CanMove()
    {
        
        if (Enemy.enemyIsDead && !miniMapClicker.mapIsOpen)
        {
            
            aIPath.canMove = true;
            mainCamera.GetComponent<Animator>().Play("Walking");

        }
        if (!Enemy.enemyIsDead || miniMapClicker.mapIsOpen)
        {
            aIPath.canMove = false;
            
        }

    }

    void OpenCloseMap()
    {
        if (miniMapClicker.mapIsOpen)
        {
            map.SetActive(true);
        }
        else
        {
            map.SetActive(false);
        }
    }

    /*
    void FindEnemy()
    {
        if (Enemy.enemyIsDead)
        {
            enemy = FindObjectOfType<Enemy>().gameObject;
        }
    }
    */


    void Hit()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDead)
        {
            //FindEnemy();
            
            AttackBar();
            CanMove();
            OpenCloseMap();
            
        }

    }
}
