using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    float BossMaxHp = 100;
    public float BossCurrHP = 100;
    public SimpleHealthBar HPbar;
    public SimpleHealthBar AttackBar;
    private Animator animator;
    public Text GameOverText;
    Player playerController;
    FloatingText floatingText;
    bool canUpdate = true;
    float TimerForAttackBar = 5.0f;
    bool DeadAnimationIsPlayed = false;
    public bool EnemyIsDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<FloatingText>();
    }

    public void DmgToBoss(float AttackValue, AudioSource HitSound, string HitAnimation)
    {
        if (!EnemyIsDead)
        {
            BossCurrHP -= AttackValue;
            floatingText.Spawn(AttackValue);
            HitSound.Play();
            playerController.attacked = true;


            HPbar.UpdateBar(BossCurrHP, BossMaxHp);

            animator.Play(HitAnimation);

            if (BossCurrHP <= 0)
            {
                isDead();
            }
        }
    }

    void isDead()
    {
        GameOverText.text = "You Won";
        GameOverText.gameObject.SetActive(true);
        animator.Play("Dying");
        EnemyIsDead = true;
        Destroy(this, 3);
    }

    void FixedUpdate()
    {
        if (EnemyIsDead)
        {
        }
        else if (playerController.isDead)
        {
            if (!DeadAnimationIsPlayed)
            {
                DeadAnimationIsPlayed = true;
                animator.Play("FistPump");
            }
        }
        else if (canUpdate)
        {
            TimerForAttackBar -= Time.deltaTime;
            AttackBar.UpdateBar(TimerForAttackBar, 5.0f);
            if (TimerForAttackBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<BossAttack>().Hit();
            StartCoroutine(CoolDown(0.7f));
            canUpdate = true;
            TimerForAttackBar = 10.0f;
        }
       

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.SetDMG(50);
    }
    

}