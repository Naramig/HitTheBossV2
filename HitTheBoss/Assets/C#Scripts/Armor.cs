﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float currHp;
    public float maxHp;
    public float dmgMod;
    public AudioClip armor;

    //GameObject parent;
    FloatingText floatingText;
    AudioSource newAudio;
    Animator animator;
    Rigidbody rb;


    Player playerController;


    private void Start()
    {
        newAudio = FindObjectOfType<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<FloatingText>();
        //parent = GetComponentInParent<GameObject>();
    }


    public void DMG()
    {
        float dmg = Mathf.Clamp(Mathf.CeilToInt(playerController.attackMod * 2) - dmgMod,0,10);

        newAudio.clip = armor;
        newAudio.Play();
        currHp -= dmg;
        floatingText.Spawn(dmg);
        if (currHp <= 0)
        {
            rb.isKinematic = false;
            transform.SetParent(null);
        }

        else if (currHp > 0)
        {
         //   animator.Play("Vibration");
            playerController.attacked = true;
        }
    }

}
