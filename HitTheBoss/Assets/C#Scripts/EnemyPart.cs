using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    public float damage;
    FloatingText floatingText;
    AudioSource newAudio;
    public AudioClip hitAudio;
    public string AnimationName;
    Boss boss;
    Player playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<Player>();
        newAudio = FindObjectOfType<AudioSource>();
        boss = FindObjectOfType<Boss>();
    }
    public void DMG()
    {
      //  float dmg = Mathf.CeilToInt(playerController.attackMod * 2) - damage;
        newAudio.clip = hitAudio;
        boss.DmgToBoss(damage, newAudio, AnimationName);
        Debug.Log("HERE");

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
