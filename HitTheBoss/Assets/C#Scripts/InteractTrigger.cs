using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    Enemy enemy;


    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "enemy")
        {
            enemy.canAttack = true;
            
        }
    }


}
