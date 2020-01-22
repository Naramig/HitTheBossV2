using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float currHp;
    public float maxHp;
    public float dmgMod;
    public AudioClip armor;

    public GameObject parent;
    FloatingText floatingText;
    AudioSource newAudio;
    Animator animator;
    Rigidbody rb;
    
    
    Player playerController;
    float dmg;

    private void Start()
    {
        newAudio = FindObjectOfType<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerController = FindObjectOfType<Player>();
        floatingText = gameObject.GetComponent<FloatingText>();
        parent = GetComponentInParent<GameObject>();
    }


    public void DMG()
    {
        dmg = Mathf.CeilToInt(playerController.attackMod * 2) - dmgMod;

        if (dmg < 0)
        {
            dmg = 0;
        }
        newAudio.clip = armor;
        newAudio.Play();
        currHp -= dmg;
        //floatingText.Spawn(dmg, parent);
        if (currHp <= 0)
        {
            rb.isKinematic = false;
            transform.SetParent(null);
        }

        else if (currHp > 0)
        {
            animator.Play("Vibration");
            playerController.attacked = true;
        }
    }





    // Update is called once per frame
    void Update()
    {
        
        
    }
}
