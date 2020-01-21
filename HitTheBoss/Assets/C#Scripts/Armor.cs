using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour
{
    public float currHp;
    public float maxHp;
    public float dmgMod;
    public AudioClip armor;
    public TextMesh text; 
    public GameObject floatingText;

    AudioSource newAudio;
    Animator animator;
    Rigidbody rb;
    GameObject newFloatingText;
    GameObject parent;
    Player playerController;
    float dmg;

    private void Start()
    {
        newAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerController = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spear")
        {
            dmg = Mathf.CeilToInt(playerController.attackMod * 2) - dmgMod;

            if (dmg < 0)
            {
                dmg = 0;
            }
            newAudio.clip = armor;
            newAudio.Play();
            currHp -= dmg;
            FloatingText();
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

    public void FloatingText()
    {
        text.text = dmg.ToString();
        
        newFloatingText = Instantiate(floatingText, playerController.mousePos+ new Vector3(0,Random.Range(0.2f,0.4f),0), Quaternion.identity, parent.transform);
        Destroy(newFloatingText,2);
    }



    // Update is called once per frame
    void Update()
    {
        
        
    }
}
