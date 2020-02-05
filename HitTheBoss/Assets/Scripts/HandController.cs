using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject ItemInHand { get; private set; }
    StaminaController stamina;
    
    void Start()
    {

    }

    private void MoveItem()
    {
        ItemInHand.transform.position = transform.position;
        ItemInHand.transform.up = transform.up;
    }

    private bool IsHasItemInHand()
    {
        if (ItemInHand)
        {
            return true;
        }
        else return false;
    }

    public bool UseItem()
    {
        if (ItemInHand.GetComponent<IWeapon>() != null)
        {
            IWeapon weapon = ItemInHand.GetComponent<IWeapon>();
            weapon.Use();
            stamina.DecreaseStamina();
            return true;
        }
        return false;
    }



    void FixedUpdate()
    {
        if (IsHasItemInHand())
        {
            MoveItem();
        }

    }
}
