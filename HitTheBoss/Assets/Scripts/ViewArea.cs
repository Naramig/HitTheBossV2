using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewArea : MonoBehaviour
{
    StaminaController staminaController;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && GetComponentInParent<StaminaController>().CurrentStamina != 0)
        {
            
            animator.SetTrigger("Attack");
        }
    }

}
