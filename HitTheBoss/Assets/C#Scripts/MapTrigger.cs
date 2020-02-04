using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MapTrigger : MonoBehaviour
{
    
    MiniMapClicker miniMapClicker;
    Player  player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        
        miniMapClicker = FindObjectOfType<MiniMapClicker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<AIPath>().canMove = false;
            miniMapClicker.mapIsOpen = true;
        }
    }
}
