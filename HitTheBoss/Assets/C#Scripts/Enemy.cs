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

    bool counterAttack = false;
    
    bool canUpdate = true;
    float TimerForAttackBar = 2.5f;
    static float maxTimerForAttakBar = 2.5f;
    bool deadAnimationIsPlaying = false;
    AnimatorClipInfo[] currentClipInfo;
    Animator m_Animator;

   
    bool deadAnimationIsPlayed = false;
    public static bool enemyIsDead;

    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<NumberSpawner>();
       
    }
    public void CtrAttack()
    {
        counterAttack = true;
        animator.Play("Reaction");
    }
    public void DmgToBoss(float AttackValue)
    {
        if (!enemyIsDead)
        {
            currHP -= AttackValue;
            floatingText.Spawn(AttackValue);
            
            playerController.attacked = true;

            hPBar.UpdateBar(currHP, maxHp);

            isDead();
           
        }
    }

    public bool isDead()
    {

        if (currHP <= 0)
        {
            animator.Play("Dying");
            Destroy(gameObject, 3);
            return true;
        }
        else
            return false;
    }
    private void OnDestroy()
    {
        enemyIsDead = true;
    }

    void FixedUpdate()
    {
        
        if (isDead())
        {
            Debug.Log("Dying");

        }
        else if (playerController.isDead)
        {
            if (!deadAnimationIsPlaying)
            {
                deadAnimationIsPlaying = true;
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
            //get current animation clip info
            currentClipInfo = this.animator.GetCurrentAnimatorClipInfo(0);
            //Access the current length of the clip
            float currentClipLength = currentClipInfo[0].clip.length;

            StartCoroutine(CoolDown(currentClipLength / 3.0f));
            counterAttack = false;
        }
        

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        if(!counterAttack)
            playerController.SetDMG(50);
    }
  

}