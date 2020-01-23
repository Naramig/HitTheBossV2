using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    
    FloatingText floatingText;
    AudioSource audio;
    public AudioClip hitAudio;
    public string animationName;
    Enemy enemy;
    Player playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<Player>();
        audio = FindObjectOfType<AudioSource>();
        enemy = FindObjectOfType<Enemy>();
    }
    public void DMG()
    {
        float dmg = Mathf.CeilToInt(playerController.attackMod * 2);
        audio.clip = hitAudio;
        enemy.DmgToBoss(dmg, audio, animationName);
        Debug.Log("HERE");

    }

}
