using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    public float damage;
    public AudioClip hiAudio;
    FloatingText floatingText;
    AudioSource newAudio;
    public string AnimationName = "";
    Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        newAudio = FindObjectOfType<AudioSource>();
        boss = FindObjectOfType<Boss>();
    }
    public void DMG()
    {
        boss.DmgToBoss(damage, newAudio, AnimationName);
        Debug.Log("HERE");

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
