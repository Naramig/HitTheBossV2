using System.Collections;
using System.Collections.Generic;
using TigerForge;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControll : MonoBehaviour
{

    EventsGroup Listeners = new EventsGroup();
    
    void Start()
    {
        Listeners.StartListening();
    }


    void MoveController()
    {

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
