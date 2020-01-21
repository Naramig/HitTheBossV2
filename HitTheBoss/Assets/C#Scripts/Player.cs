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
    AIPath aIPath;
    AIDestinationSetter destinationSetter;
    Spear spear;
    
    Armor armor;
    bool canTap = true;
    public bool attacked;
    float canTapTimer = 0.5f;
    float canAttackTimer = 4;
    float maxAttackValue = 4;

    private void Start()
    {
        armor = GetComponent<Armor>();
        aIPath = GetComponent<AIPath>();
        aIPath.canMove = false;
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

    void Hit()
    {

            Debug.Log(canTap);
            if (canTap)
            {
                canTapTimer -= Time.deltaTime;
                if (Input.GetMouseButtonDown(0))
                {
                Debug.Log("tap");
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit);

                    if (hit.collider != null)
                    {
                    //spear.speared = false;
                       hit.point = mousePos;
                       armor.DMG();
                       armor.FloatingText();
                    Debug.Log(armor.dmgMod);

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
