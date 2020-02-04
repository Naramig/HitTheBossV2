using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{

    Enemy enemy;

    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goblin")
        {
            
            if (!enemy.canUpdate)
            {
                Debug.Log("attack");
                enemy.GetComponent<Animator>().Play("JumpForward");
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Goblin")
        {
          
        }

    }

    void Update()
    {
        
    }
}
