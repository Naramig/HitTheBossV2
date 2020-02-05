using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    Animator animator;
    Enemy enemy;
    PlayerController  playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        enemy = FindObjectOfType<Enemy>();
        animator = enemy.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goblin")
        {
            animator.SetTrigger("CalmDown");
            Debug.Log("interact");
            //playerController.canMoveForward = false;
            enemy.isTriggered = true;
            playerController.canAttack = true;

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Goblin")
        {
            enemy.isTriggered = true;
            playerController.canAttack = true;
            if (!enemy.canUpdate)
            {
                //Debug.Log("attackMTHFCKA");
                //enemy.HitAnimation();
                animator.SetTrigger("Attack");
                
            }
            else if (enemy.canUpdate)
            {
                animator.SetTrigger("JumpBack");
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Goblin")
        {
            //playerController.canMoveForward = true;
            enemy.isTriggered = false;
            playerController.canAttack = false;

        }
    }


}
