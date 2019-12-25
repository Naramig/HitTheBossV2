using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    
    public void SuitDown()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
