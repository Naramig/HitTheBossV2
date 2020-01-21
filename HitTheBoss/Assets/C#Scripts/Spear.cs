using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Player playerController;
    float canSpearedTimer = 0.5f;
    
    public bool speared = false;
    Vector3 startPos;
    Quaternion startRot;

    private void Start()
    {
        playerController = GetComponentInParent<Player>();
        startPos = transform.position;
        startRot = transform.rotation;
    }


    public void SpearAnimation()
    {
        
        if (speared)
        {
            
            canSpearedTimer -= Time.deltaTime;
            if (canSpearedTimer > 0)
            {
                
                transform.rotation = Quaternion.LookRotation(playerController.mousePos - transform.position);
                transform.position = Vector3.Lerp(transform.position, playerController.mousePos - new Vector3(0, 0, 2.5f), Time.deltaTime);
            }

            if (canSpearedTimer <= -0.5f)
            {
                speared = false;
            }
            if (canSpearedTimer <= 0 )
            {
                transform.rotation = startRot;
                transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);
            }

        }

        if (!speared)
        {
            canSpearedTimer = 0.5f;            
        }
    }

    private void Update()
    {
        SpearAnimation();
    }


}
