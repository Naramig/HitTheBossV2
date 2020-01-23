using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MapTrigger : MonoBehaviour
{
    
    MiniMapClicker miniMapClicker;
    Player playerController;

    private void Start()
    {
        playerController = FindObjectOfType<Player>();
        
        miniMapClicker = FindObjectOfType<MiniMapClicker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerController.GetComponent<AIPath>().canMove = false;
            miniMapClicker.mapIsOpen = true;
        }
    }
}
