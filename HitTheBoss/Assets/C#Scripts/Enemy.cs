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
   
    public bool canAttack;

    Player playerController;
    NumberSpawner floatingText;
    
    bool canUpdate = true;
    float TimerForAttackBar = 2.5f;
    static float maxTimerForAttakBar = 2.5f;
    bool deadAnimationIsPlayed = false;
    public static bool enemyIsDead;

    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<NumberSpawner>();
       
    }

    public void DmgToBoss(float AttackValue)
    {
        if (!enemyIsDead)
        {
            currHP -= AttackValue;
            floatingText.Spawn(AttackValue);
            
            playerController.attacked = true;

            hPBar.UpdateBar(currHP, maxHp);

            if (currHP <= 0)
            {
                isDead();
            }
        }
    }

    void isDead()
    {

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
            attackBar.UpdateBar(TimerForAttackBar, maxTimerForAttakBar);
            if (TimerForAttackBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            gameObject.GetComponent<EnemyAttack>().Hit();
            
            canUpdate = true;
            TimerForAttackBar = maxTimerForAttakBar;
            StartCoroutine(CoolDown(0.7f));
        }
        

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.SetDMG(50);
    }
    

}