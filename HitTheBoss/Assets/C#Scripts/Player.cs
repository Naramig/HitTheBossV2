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
    public Camera cam;
    public Vector3 mousePos;
    public SimpleHealthBar attackBar;
    public SimpleHealthBar healthBar;
    public Text gameOverText;
    public GameObject map;

    AIPath aIPath;
    Spear spear;
    Shield shield;
    Ray ray;
    Armor armor;
    Enemy enemy;
    MiniMapClicker miniMapClicker;
    RaycastHit hit;

    float canTapTimer = 1f;
    float canAttackTimer = 2;
    float maxAttackValue = 2;
    bool canTap = true;



    private void Start()
    {
        
        spear = GetComponentInChildren<Spear>();
        armor = FindObjectOfType<Armor>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
        //enemy = FindObjectOfType<Enemy>();
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

    void AttackBar()
    {
        if (!attacked)
        {
            canAttackTimer -= Time.deltaTime;
            attackMod += Time.deltaTime;
            attackBar.UpdateBar(attackMod, maxAttackValue);

            if (attackMod >= 2)
            {
                attackMod = 2;
            }
        }
        if (attacked)
        {
            canAttackTimer = 2;
            attacked = false;
            attackMod = 0;
        }
    }

    void CanMove()
    {
        
        if (Enemy.enemyIsDead && !miniMapClicker.mapIsOpen)
        {
            
            aIPath.canMove = true;
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

    void Hit()
    {
        
        if (canTap)
        {
            

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = Input.mousePosition;
                ray = cam.ScreenPointToRay(mouse);


               

                if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("pickable")))
                {
                    canTap = false;
                    mousePos = hit.point;
                    spear.speared = true;
                    if (hit.collider.gameObject.CompareTag("armor"))
                    {

                        hit.collider.gameObject.GetComponent<Armor>().DMG();
                    }
                    else if (hit.collider.gameObject.CompareTag("Enemy"))
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
                canTapTimer = 1f;
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
