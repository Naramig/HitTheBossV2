using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float bossCurrHP = 100;
    public bool enemyIsDead = false;
    public float bossMaxHp = 100;
    public SimpleHealthBar hPbar;
    public SimpleHealthBar attackBar;
    public Text gameOverText;

    
    private bool canUpdate = true;
    private float timerForAttackBar = 5.0f;
    private bool deadAnimationIsPlaying = false;
    private Animator animator;

    Player playerController;
    FloatingText floatingText;
    

    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<FloatingText>();
    }

    public void DmgToBoss(float attackValue, AudioSource hitSound, string hitAnimation)
    {
        if (!enemyIsDead)
        {
            bossCurrHP -= attackValue;
            floatingText.Spawn(attackValue);
            hitSound.Play();
            playerController.attacked = true;


            hPbar.UpdateBar(bossCurrHP, bossMaxHp);

            animator.Play(hitAnimation);

            if (bossCurrHP <= 0)
            {
                IsDead();
            }
        }
    }

    void IsDead()
    {
        gameOverText.text = "You Won";
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(CoolDownDead(3.7f));
        enemyIsDead = true;
        Destroy(this, 3);
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
            if (!deadAnimationIsPlaying)
            {
                deadAnimationIsPlaying = true;
                animator.Play("Won");
            }
        }
        else if (canUpdate)
        {
            timerForAttackBar -= Time.deltaTime;
            attackBar.UpdateBar(timerForAttackBar, 5.0f);
            if (timerForAttackBar <= 0)
            {
                canUpdate = false;
            }
        }
        else
        {
            this.gameObject.GetComponent<BossAttack>().Hit();
            StartCoroutine(CoolDown(0.7f));
            canUpdate = true;
            timerForAttackBar = 10.0f;
        }
       

    }
    
    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        playerController.SetDMG(50);
    }
    IEnumerator CoolDownDead(float time)
    {
        yield return new WaitForSeconds(time);
        animator.Play("Dying");
    }

}