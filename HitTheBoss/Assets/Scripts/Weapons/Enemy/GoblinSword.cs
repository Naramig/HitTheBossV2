using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSword : MonoBehaviour, IWeapon
{
    private float dmg = 15;
    public void DoDamage(Collider other)
    {
        other.GetComponent<IBodyPart>().GetDMG(other.GetComponent<StaminaController>());
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            DoDamage(other);
        }
    }
}
