using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyPart : MonoBehaviour, IEnemyBodyPart
{
    float CurrentHP;
    //float maxHP;
    float dmgMod;
    public GameObject player;
    StaminaController playersStamina;
    NumberSpawner floatingText;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        floatingText = GetComponent<NumberSpawner>();
        playersStamina = player.GetComponent<StaminaController>();
        
    }
    public void GetDMG()
    {
        float dmg = Mathf.Clamp(Mathf.CeilToInt(playersStamina.CurrentStamina* 3) - dmgMod, 0, 10);

        //newAudio.clip = armor;
        //newAudio.Play();
        floatingText.Spawn(dmg);

        if(gameObject.tag == "Armor")
        {
            CurrentHP -= dmg;
            if ((CurrentHP <= 0 || playersStamina.CurrentStamina == playersStamina.maxStamina))
            {
                rigidbody.isKinematic = false;
                transform.SetParent(null);

            }
            if (CurrentHP > 0)
            {
                //   animator.Play("Vibration");

            }
        }
        else
        {
            GetComponent<HPController>().CurrentHP -= dmg;
        }

        


    }
}
