using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyPart : MonoBehaviour, IEnemyBodyPart
{

    float dmgMod;
    public GameObject player;
    StaminaController playersStamina;
    NumberSpawner floatingText;


    private void Start()
    {
        
        floatingText = GetComponent<NumberSpawner>();
        playersStamina = player.GetComponent<StaminaController>();
        
    }
    public void GetDMG()
    {
        float dmg = Mathf.Clamp(Mathf.CeilToInt(playersStamina.CurrentStamina* 3) - dmgMod, 0, 10);

        //newAudio.clip = ;
        //newAudio.Play();
        floatingText.Spawn(dmg);
        GetComponent<HPController>().CurrentHP -= dmg;

    }
}
