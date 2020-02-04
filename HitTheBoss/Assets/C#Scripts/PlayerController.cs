using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{




    public Camera mainCamera;
    public Vector3 mousePos;
    Spear spear;
    RaycastHit hit;
    float canTapTimer = 0.5f;
    bool canTap = true;
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public bool canMoveForward;
    public bool canMoveBack;
    public bool canAttack;

    void Start()
    {
        spear = GetComponentInChildren<Spear>();
    }

    public void Move()
    {

        /*
#if UNITY_ANDROID
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    UpSwipe();
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    DownSwipe();
                    Debug.Log("down swipe");
                }


            }
            */


        if (canTap)
        {
            if (Input.GetMouseButtonDown(0))
            {

                //save began touch 2d point
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0.55f )
                {
                    UpSwipe();
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < -0.55f )
                {
                    DownSwipe();
                    Debug.Log("down swipe");
                }

                if (Mathf.Abs(currentSwipe.y) == 0f && canAttack)
                {
                    Vector3 mouse = Input.mousePosition;
                    Ray ray = mainCamera.ScreenPointToRay(mouse);

                    if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("pickable")))
                    {
                        canTap = false;
                        mousePos = hit.point;
                        spear.speared = true;
                        if (hit.collider.gameObject.CompareTag("armor") && !FindObjectOfType<Enemy>().attacked)
                        {

                            hit.collider.gameObject.GetComponent<Armor>().DMG();
                        }
                        else if (hit.collider.gameObject.CompareTag("Enemy") && !FindObjectOfType<Enemy>().attacked)
                        {
                            hit.collider.gameObject.GetComponent<EnemyPart>().DMG();

                        }
                        else if (hit.collider.gameObject.CompareTag("CounterAttackTrigger"))
                        {
                            hit.collider.gameObject.GetComponentInParent<Enemy>().CounterAttack();

                        }
                    }
                }

            }



        }
        if (!canTap)
        {
            canTapTimer -= Time.deltaTime;
            if (canTapTimer <= 0)
            {

                canTap = true;
                canTapTimer = 0.5f;
            }


        }

    }

    

    void UpSwipe()
    {

            transform.position -= new Vector3(0, 0, 5);
        
    }

    void DownSwipe()
    {

        transform.position += new Vector3(0, 0, 5);

    }

    void Update()
    {
        Move();
    }
}
