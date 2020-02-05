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
        startPos = transform.position;
        enemy = GetComponent<Enemy>();
        Debug.Log(startPos);
    }

    void StartJumpBack()
    {
        //startPos = endPos;
        canMoveBack = true;
    }
    void StopJumpBack()
    {
        
        canMoveBack = false;
        
    }

    void StartJumpForward()
    {

        //startPos = endPos;
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
        else
        {
            endPos = transform.position;
            //Debug.Log(endPos);
        }

        if (canMoveBack)
        {
            transform.position -= new Vector3(0, 0, 0.07f);
        }
        else
        {
            endPos = transform.position;
            //Debug.Log(endPos);
        }

    }
}
