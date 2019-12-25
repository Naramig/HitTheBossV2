using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;

    public SimpleHealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void DMG(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            this.GetComponent<Animator>().Play("Dead");
        }
        healthBar.UpdateBar(currentHP, maxHP);
    }


    // Update is called once per frame
    void Update()
    {
    }
}
