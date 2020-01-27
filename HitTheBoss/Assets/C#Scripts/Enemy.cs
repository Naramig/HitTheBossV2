using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftFoot;
    public GameObject leftHand;
    public GameObject sphere;
    public float currHP = 100;
    public SimpleHealthBar hPBar;
    public SimpleHealthBar attackBar;
    public static bool enemyIsDead;
    public bool canAttack;

    GameObject temp;
    Player playerController;
    NumberSpawner floatingText;
    Animator animator;
    

    
    string[] animations = {"Attack1", "Attack2", "Attack3", "Attack4", "Attack5", "Attack7" };
    bool canUpdate = true;
    float TimerForAttackBar = 5f;
    static float maxTimerForAttakBar = 5f;
    float maxHp = 100;
    bool counterAttacked = false;

    


    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<NumberSpawner>();
        
    }


    public void CounterAttack()
    {

        animator.Play("Reaction");
        counterAttacked = true;
        
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

    public void HitAnimation()
    {
        int rnd = Random.Range(0, animations.Length - 1);
            
            Vector3 positionOfSphere = new Vector3(0, 0, 0);

            
            if (rnd >= 0 && rnd <= 4)
                temp = rightHand;
            else if (rnd >= 5 && rnd <= 5)
                temp = leftHand;
            else if (rnd >= 6 && rnd <= 6)
                temp = leftFoot;

            GameObject NewSphere = Instantiate(sphere, temp.transform.position, Quaternion.identity);
            NewSphere.transform.SetParent(temp.transform);
            GetComponent<Animator>().Play(animations[rnd]);
            Destroy(NewSphere, 1);
        counterAttacked = false;
        TimerForAttackBar = maxTimerForAttakBar;
        canUpdate = true;
    }

    void Hit()
    {
        if (!counterAttacked)
        {
            playerController.SetDMG(15);
            
            
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

    bool DeadAnimation()
    {
        animator.Play("Won");
        return true;
    }
    void AttackBarUpdate()
    {
        TimerForAttackBar -= Time.deltaTime;
        //
        attackBar.UpdateBar(TimerForAttackBar, maxTimerForAttakBar);
        if (TimerForAttackBar <= 0)
        {
            
            canUpdate = false;
        }
    }

    void FixedUpdate()
    {
       
        if (isDead())
        {
            Debug.Log("Dying");

        }
        else if (playerController.isDead)
        {
            if (!DeadAnimation())
            {
                DeadAnimation();
            }
        }
        else if (canUpdate)
        {
            AttackBarUpdate();
        }
        else
        {

            HitAnimation();
        }
        

    }
    

  

}