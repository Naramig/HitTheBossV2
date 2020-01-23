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
    public Camera cam;
    public Vector3 mousePos;
    public bool attacked;
    public SimpleHealthBar attackBar;
    public SimpleHealthBar healthBar;
    public Text GameOverText;
    public bool isDead = false;

    AIPath aIPath;
    
    Spear spear;
    Shield shield;
    Ray ray;
    Armor armor;
    Boss boss;
    Map map;
    bool canTap = true;
    
    float canTapTimer = 0.5f;
    float canAttackTimer = 4;
    float maxAttackValue = 4;
    RaycastHit hit;


    private void Start()
    {
        spear = GetComponentInChildren<Spear>();
        armor = FindObjectOfType<Armor>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
        boss = FindObjectOfType<Boss>();
        shield = GetComponentInChildren<Shield>();
        map = FindObjectOfType<Map>();
    }

    public void SetDMG(float dmg)
    {
        if (!shield.shielded)
        {
            currHp -= dmg;
            healthBar.UpdateBar(currHp,maxHp);
            if (currHp <= 0)
            {
                isDead = true;
                GameOverText.text = "GameOver";
                GameOverText.gameObject.SetActive(true);
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

            if (attackMod >= 4)
            {
                attackMod = 4;
            }
        }
        if (attacked)
        {
            canAttackTimer = 4;
            attacked = false;
            attackMod = 0;
        }
    }

    void CanMove()
    {
        if (boss.EnemyIsDead && map.MapIsOpen)
        {
            aIPath.canMove = true;
        }
    }
    void Hit()
    {

        if (canTap)
        {
            canTapTimer -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouse = Input.mousePosition;
                ray = cam.ScreenPointToRay(mouse);


               

                if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("pickable")))
                {
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
                }
            }

            if (canTapTimer <= 0)
            {
                canTap = false;
            }
        }

        if (!canTap)
        {
            canTap = true;
            canTapTimer = 0.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Hit();
        AttackBar();
        CanMove();
    }
}
