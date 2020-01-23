using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    float BossMaxHp = 100;
    public float BossCurrHP = 100;
    public SimpleHealthBar HPbar;
    public SimpleHealthBar AttakBar;
    private Animator animator;
    public Text GameOverText;
    Player playerController;
    bool canUpdate = true;
    float TimerForAttakBar = 5.0f;
    bool DeadAnimationIsPlayed = false;


    public void DmgToBoss(float AttackValue, AudioSource HitSound, string HitAnimation)
    {
        BossCurrHP -= AttackValue * 2;

        HitSound.Play(0);

        //add floatingText here

        HPbar.UpdateBar(BossCurrHP, BossMaxHp);

        animator.Play(HitAnimation);

        if (BossCurrHP <= 0)
        {
            isDead();
        }
    }

    void isDead()
    {
        GameOverText.text = "You Won";
        GameOverText.gameObject.SetActive(true);
        animator.Play("Dying");
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerController.isDead)
        {
            if (!DeadAnimationIsPlayed)
            {
                DeadAnimationIsPlayed = true;
                animator.Play("FistPump");
            }
        }
        else if (canUpdate)
        {
            TimerForAttakBar -= Time.deltaTime;
            AttakBar.UpdateBar(TimerForAttakBar, 5.0f);
            if (TimerForAttakBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<BossAttack>().Hit();
            StartCoroutine(CoolDown(0.7f));
            canUpdate = true;
            TimerForAttakBar = 10.0f;
        }
       

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.SetDMG(50);
    }
    

}