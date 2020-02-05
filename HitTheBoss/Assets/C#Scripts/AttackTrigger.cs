using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    Animator animator;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        animator = GetComponent<Animator>();
    }

    void RayToAttack()
    {
        if (!enemy.isTriggered)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 7, LayerMask.GetMask("Player")))
            {
                if (!enemy.canUpdate)
                {
                    //Debug.Log("attack");
                    animator.SetTrigger("JumpForward");
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow, 10);


            }
            else
            {
                animator.SetTrigger("CalmDown");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 7, Color.white, 10);
                Debug.Log("Did not Hit");
            }
        }
    }

    void FixedUpdate()
    {
        RayToAttack();
    }

    /*
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


    */
}
