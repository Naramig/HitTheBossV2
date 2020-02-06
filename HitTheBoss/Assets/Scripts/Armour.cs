using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armour : MonoBehaviour, IBodyPart
{
    public float CurrentHP;
    //float maxHP;
    float dmgMod = 1;
    
    NumberSpawner floatingText;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        floatingText = GetComponent<NumberSpawner>();
    }
    public void GetDMG(StaminaController staminaController)
    {
        float dmg = Mathf.Clamp(Mathf.CeilToInt(staminaController.CurrentStamina * 3) - dmgMod, 0, 10);

        //newAudio.clip = armor;
        //newAudio.Play();
        floatingText.Spawn(dmg);

            CurrentHP -= dmg;
            if ((CurrentHP <= 0 || staminaController.CurrentStamina == staminaController.maxStamina))
            {
                rigidbody.isKinematic = false;
                transform.SetParent(null);

            }
            if (CurrentHP > 0)
            {
                //   animator.Play("Vibration");

            }
        }
}




