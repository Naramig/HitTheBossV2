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

    public SimpleHealthBar attackBar;
    public SimpleHealthBar HelthBar;

    AIPath aIPath;
    AIDestinationSetter destinationSetter;
    Spear spear;
    Ray ray;
    Armor armor;
    bool canTap = true;
    public bool attacked;
    float canTapTimer = 0.5f;
    float canAttackTimer = 4;
    float maxAttackValue = 4;

    private void Start()
    {
        spear = GetComponentInChildren<Spear>();

        armor = FindObjectOfType<Armor>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
        Debug.Log(cam.name);
    }

    void AttackBar()
    {
        if (!attacked)
        {
            canAttackTimer -= Time.deltaTime;
            attackMod += Time.deltaTime;
            attackBar.UpdateBar(attackMod, maxAttackValue);

            if (attackMod >= 10)
            {
                attackMod = 10;
            }
        }
        if (attacked)
        {
            canAttackTimer = 4;
            attacked = false;
            attackMod = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(ray);
    }

    }
    void Hit()
    {

        if (canTap)
            {
                canTapTimer -= Time.deltaTime;
                if (Input.GetMouseButtonDown(0))
                {
                
                ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);
                Debug.Log(canTapTimer);

                if (hit.collider != null)
                {
                
                mousePos = hit.point;
                spear.speared = true;
                Debug.Log(mousePos);
                //armor.DMG();
                //armor.FloatingText();


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
    }
}
