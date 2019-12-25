using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    float currentHP;
    public float maxHP = 500;
    public GameObject enemy;
    public float HeadDamage = 25;
    public float BodyDamage = 10;
    public float ArmDamage = 5;
    public float LegDamage = 5;
    public GameObject armor;
    EnemyScript enemyScript;

    void Start()
    {
        currentHP = maxHP;
        enemyScript = enemy.GetComponent<EnemyScript>();
    }
    void Attack()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "head")
            {
                enemyScript.DMG(HeadDamage);
                Debug.Log(enemyScript.currentHP);
            }
            if (hit.collider.gameObject.tag == "Body")
            {
                enemyScript.DMG(BodyDamage);
            }
            if (hit.collider.gameObject.tag == "LeftArm" || hit.collider.gameObject.tag == "RightArm")
            {
                enemyScript.DMG(ArmDamage);
            }
            if (hit.collider.gameObject.tag == "LeftLeg" || hit.collider.gameObject.tag == "RightLeg")
            {
                enemyScript.DMG(LegDamage);
            }
            if (hit.collider.gameObject.tag == "Armor")
            {
                armor.GetComponent<Armor>().SuitDown();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.UpdateBar(currentHP, maxHP);
        Attack();
    }
}
