using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    Enemy enemy;
    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        enemy = FindObjectOfType<Enemy>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goblin")
        {
            Debug.Log("interact");
            //playerController.canMoveForward = false;
            enemy.isTriggered = true;
            playerController.canAttack = true;
            if (!enemy.canUpdate)
            {
                enemy.HitAnimation();
            }
            else
            {
                enemy.GetComponent<Animator>().SetTrigger("JumpBack");
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
