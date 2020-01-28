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

    AIPath aIPath;
    Spear spear;
    Shield shield;
    
    MiniMapClicker miniMapClicker;
    RaycastHit hit;
    Enemy enemy;
   

    float canTapTimer = 0.5f;
    float canAttackTimer = 1.5f;
    float maxAttackValue = 1.5f;
    bool canTap = true;



    private void Start()
    {
        
        spear = GetComponentInChildren<Spear>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
        shield = GetComponentInChildren<Shield>();
        miniMapClicker = FindObjectOfType<MiniMapClicker>();
        aIPath.canMove = false;
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
        float chanse = 50;
        if (chanse>=Random.Range(0f, 100f))
        {
            spear.GetComponentInChildren<Animator>().Play("Dodge");
            Debug.Log("Dodge");
            return true;
        }
        else
        {
            Debug.Log("!Dodge");
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
            }
        }
        if (attacked)
        {
            canAttackTimer = maxAttackValue;
            attacked = false;
            attackMod = 0;
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
            //mainCamera.GetComponent<Animator>().Play("New State");
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

    void Hit()
    {
        
        if (canTap)
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = Input.mousePosition;
                Ray ray = mainCamera.ScreenPointToRay(mouse);

                if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("pickable")))
                {
                    canTap = false;
                    mousePos = hit.point;
                    spear.speared = true;
                    if (hit.collider.gameObject.CompareTag("armor") && !FindObjectOfType<Enemy>().attacked)
                    {

                        hit.collider.gameObject.GetComponent<Armor>().DMG();
                    }
                    else if (hit.collider.gameObject.CompareTag("Enemy") && !FindObjectOfType<Enemy>().attacked)
                    {
                        hit.collider.gameObject.GetComponent<EnemyPart>().DMG();

                    }
                    else if (hit.collider.gameObject.CompareTag("CounterAttackTrigger"))
                    {
                        hit.collider.gameObject.GetComponentInParent<Enemy>().CounterAttack();
                        
                    }
                }
            }

        }

        if (!canTap)
        {
            canTapTimer -= Time.deltaTime;
            if (canTapTimer <= 0)
            {
                
                canTap = true;
                canTapTimer = 0.5f;
            }
            
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDead)
        {
            Hit();
            AttackBar();
            CanMove();
            OpenCloseMap();
        }
    }
}
