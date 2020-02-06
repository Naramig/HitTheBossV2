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


    bool JumpBack()
    {
        
    }
    bool JumpForward()
    {

    }


    void Move()
    {
        if (JumpBack())
        {
            transform.position += new Vector3(0, 0, 0.07f);
        }
        if (JumpForward())
        {
            transform.position -= new Vector3(0, 0, 0.07f);
        }
    }

    private void Update()
    {
        Move();
    }

}
