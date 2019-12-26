using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float ArmorHP = 30;
    public void ArmorDMG(float TakeHpFromArmor)
    {
            ArmorHP -= TakeHpFromArmor;

            if (ArmorHP <= 0)
            {
                GetComponent<Rigidbody>().isKinematic = false;
            }                
    }
}
