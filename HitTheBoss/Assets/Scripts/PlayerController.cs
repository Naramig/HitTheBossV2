using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    public float HP;
    public SimpleHealthBar healthBar;
    float current = 0;
    float max = 0;
    public GameObject enemy;

    float HeadDamage = 25;
    void Start()
    {

    }



    public void DMG(float dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            HP = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
       // healthBar.UpdateBar(current, max);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Convert mouse position to raycast
        RaycastHit hit;
        print(enemy.GetComponent<EnemyScript>().HP); 

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
           
            if (hit.collider.gameObject.tag == "head")
            {
                enemy.GetComponent<EnemyScript>().HP -= HeadDamage;
            }
        }
    }
}
