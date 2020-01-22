using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shield : MonoBehaviour
{
    public bool shielded;
    Animator animator;

    private void Start()
    {
        
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            shielded = true;
            animator.Play("shieldAnimation");
        }
        if (Input.GetMouseButtonDown(0))
        {
            shielded = false;
            animator.Play("shieldAnimationRevert");
        }

    }


}
