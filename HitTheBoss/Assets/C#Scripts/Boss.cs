using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    float BossMaxHp = 100;
    public float BossCurrHP = 100;
    public GameObject HPbar;
    public GameObject AttakBar;
    private Animator anim;
    public Text GameOverText;

    bool canUpdate = true;
    float TimerForAttakBar = 5.0f;



    void DmgToBoss(float AttackValue, AudioSource HitSound, string HitAnimation)
    {
        BossCurrHP -= AttackValue * 2;

        HitSound.Play(0);

        //add floatingText here

        HPbar.GetComponent<SimpleHealthBar>().UpdateBar(BossCurrHP, BossMaxHp);

        anim.Play(HitAnimation);

        if (BossCurrHP <= 0)
        {
            isDead();
        }
    }

    void isDead()
    {
        GameOverText.text = "You Won";
        GameOverText.enabled = true;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (canUpdate)
        {
            TimerForAttakBar -= Time.deltaTime;
            AttakBar.GetComponent<SimpleHealthBar>().UpdateBar(TimerForAttakBar, 5.0f);
            if (TimerForAttakBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<BossAttack>().Hit();
            StartCoroutine(CoolDown(0.7f));
            //   Player.GetComponent<PlayerScript>().setDmg(50);
            canUpdate = true;
            TimerForAttakBar = 10.0f;
        }

    }
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
    }

}