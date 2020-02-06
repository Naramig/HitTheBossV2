using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour, IBodyPart
{
    float dmgMod;
    NumberSpawner floatingText;

    private void Start()
    {
        floatingText = GetComponent<NumberSpawner>();
    }
    public void GetDMG(StaminaController staminaController)
    {
        float dmg = Mathf.Clamp(Mathf.CeilToInt(staminaController.CurrentStamina* 3) - dmgMod, 0, 10);
        //newAudio.clip = ;
        //newAudio.Play();
        floatingText.Spawn(dmg);
        GetComponent<HPController>().CurrentHP -= dmg;

    }
}
