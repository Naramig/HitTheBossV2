﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public PlayerController  playerController;
    float canSpearedTimer = 0.2f;
    
    public bool speared = false;
    Vector3 startPos;
    Quaternion startRot;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
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
                GetComponentInChildren<Animator>().Play("Hit");
                transform.rotation = Quaternion.LookRotation(playerController.mousePos - transform.position);
                transform.position = Vector3.Lerp(transform.position, playerController.mousePos + new Vector3(0, 0, 0.5f), 0.2f);
            }

            if (canSpearedTimer <= -0.2f)
            {
                speared = false;
            }
            if (canSpearedTimer <= 0 )
            {
                transform.rotation = Quaternion.Lerp(transform.rotation,startRot,0.2f);
                transform.position = Vector3.Lerp(transform.position, startPos, 0.2f);
            }

        }
        if (!speared)
        {
            canSpearedTimer = 0.2f;
            
        }
    }

    private void Update()
    {
        
        SpearAnimation();
    }


}
