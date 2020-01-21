using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    public Player playerController;
    float canSpearedTimer = 0.01f;
    
    public bool speared = false;
    Vector3 startPos;

    private void Start()
    {
        playerController = GetComponent<Player>();
        startPos = transform.position;
    }


    void SpearAnimation()
    {
        if (speared)
        {
            canSpearedTimer -= Time.deltaTime;
            if (canSpearedTimer > 0)
            {
                transform.rotation = Quaternion.LookRotation(playerController.mousePos - startPos);
                transform.position = Vector3.Lerp(transform.position, playerController.mousePos + new Vector3(0, 0, 0.5f), Time.deltaTime);
            }
            if (canSpearedTimer <= 0)
            {
                transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime);

                if (canSpearedTimer <= 0.5)
                {

                    speared = false;
                }
            }
            
        }
        if (!speared)
        {
            canSpearedTimer = 0.01f;            
        }
    }

    private void Update()
    {
        SpearAnimation();
    }


}
