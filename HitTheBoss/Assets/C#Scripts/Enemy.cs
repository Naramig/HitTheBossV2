using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float maxHp = 100;
    public float currHP = 100;
    public SimpleHealthBar hPBar;
    public SimpleHealthBar attackBar;
    private Animator animator;
    public Text gameOverText;

    Player playerController;
    FloatingText floatingText;

    bool canUpdate = true;
    float TimerForAttackBar = 2.5f;
    static float maxTimaerForAttakBar = 2.5f;
    bool deadAnimationIsPlayed = false;
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
            currHP -= AttackValue;
            floatingText.Spawn(AttackValue);
            HitSound.Play();
            playerController.attacked = true;


            hPBar.UpdateBar(currHP, maxHp);

            animator.Play(HitAnimation);

            if (currHP <= 0)
            {
                isDead();
            }
        }
    }

    void isDead()
    {

        gameOverText.text = "You Won";
        gameOverText.gameObject.SetActive(true);
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
            if (!deadAnimationIsPlayed)
            {
                deadAnimationIsPlayed = true;
                animator.Play("Won");
            }
        }
        else if (canUpdate)
        {
            TimerForAttackBar -= Time.deltaTime;
            attackBar.UpdateBar(TimerForAttackBar, maxTimaerForAttakBar);
            if (TimerForAttackBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<EnemyAttack>().Hit();
            
            canUpdate = true;
            TimerForAttackBar = maxTimaerForAttakBar;
            StartCoroutine(CoolDown(0.7f));
        }
        

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.SetDMG(50);
    }
    

}