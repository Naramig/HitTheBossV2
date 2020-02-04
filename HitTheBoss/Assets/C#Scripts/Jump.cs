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
        Debug.Log("stopBCK");
        canMoveBack = false;
        endPos = transform.position;
    }

    void StartJumpForward()
    {
        Debug.Log("startFRWRD");
        transform.position = endPos;
        canMoveForward = true;
    }
    public void StopJumpForward()
    {
        Debug.Log("stopFRWRD");
        //transform.position = startPos;
        canMoveForward = false;
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
