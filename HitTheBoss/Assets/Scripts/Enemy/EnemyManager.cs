using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Animator animator;

    float currentHP;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHP = GetComponent<HPController>().CurrentHP;
    }


    void JumpBack()
    {
        animator.SetTrigger("JumpBack");
        for (;transform.position!= new Vector3(0, 0, 2f); )
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, 2f), 0.2f);
        }
    }

    void JumpForward()
    {
        animator.SetTrigger("JumpForward");
        for (; transform.position != new Vector3(0, 0, 2f);)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -2f), 0.2f);
        }
    }

}
