using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    
    Vector3 startPos;
    Vector3 endPos;
    bool canMoveForward;
    bool canMoveBack;
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void StartJumpBack()
    {
        startPos = transform.position;
        canMoveBack = true;
    }
    void StopJumpBack()
    {
        
        canMoveBack = false;
        endPos = transform.position;
    }

    void StartJumpForward()
    {
        
        transform.position = endPos;
        canMoveForward = true;
        //enemy.attacked = false;
    }
    public void StopJumpForward()
    {
        
        //transform.position = startPos;
        canMoveForward = false;
        //enemy.HitAnimation();
    }


    private void FixedUpdate()
    {
        if (canMoveForward)
        {
            transform.position += new Vector3(0, 0, 0.07f);
        }
        if (canMoveBack)
        {
            transform.position -= new Vector3(0, 0, 0.07f);
        }
    }
}
