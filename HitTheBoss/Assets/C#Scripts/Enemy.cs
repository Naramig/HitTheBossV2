using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float MaxHp = 100;
    public float CurrHP = 100;
    public SimpleHealthBar HPBar;
    public SimpleHealthBar AttackBar;
    private Animator animator;
    public Text GameOverText;

    Player playerController;
    FloatingText floatingText;

    bool canUpdate = true;
    float TimerForAttackBar = 5.0f;
    bool DeadAnimationIsPlayed = false;
    public bool enemyIsDead;

    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<FloatingText>();
    }

    public void DmgToBoss(float AttackValue, AudioSource HitSound, string HitAnimation)
    {
        if (!enemyIsDead)
        {
            CurrHP -= AttackValue;
            floatingText.Spawn(AttackValue);
            HitSound.Play();
            playerController.attacked = true;


            HPBar.UpdateBar(CurrHP, MaxHp);

            animator.Play(HitAnimation);

            if (CurrHP <= 0)
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
        Destroy(gameObject, 3);
        
        
    }
    private void OnDestroy()
    {
        enemyIsDead = true;
    }

    void FixedUpdate()
    {
        if (enemyIsDead)
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
            this.gameObject.GetComponent<EnemyAttack>().Hit();
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