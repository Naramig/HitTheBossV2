using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{

    HandController handController;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    void Start()
    {
        handController = GetComponent<HandController>();
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }


    void MoveController()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;


                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        if (lp.x > fp.x)
                        {
                            Debug.Log("Right Swipe");
                        }
                        else
                        {
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {
                        if (lp.y > fp.y)
                        {
                            Debug.Log("Up Swipe");
                        }
                        else
                        {
                            Debug.Log("Down Swipe");
                        }
                    }
                }

                else
                {
                    //handController.UseItem();
                    Debug.Log("Tap");
                }
            }
        }
    }




    
    void FixedUpdate()
    {
        MoveController();
    }
}
