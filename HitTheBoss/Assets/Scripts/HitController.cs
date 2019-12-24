using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HitController : MonoBehaviour
{
    public float HP;
    public SimpleHealthBar healthBar;
    float current = 0;
    float max = 0;
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
        //healthBar.UpdateBar(current, max);
    }
}
