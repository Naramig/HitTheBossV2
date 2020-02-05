using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Enemy : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftFoot;
    public GameObject leftHand;
    public GameObject sphere;
    public float currHP;
    public float maxHp;
    public SimpleHealthBar hPBar;
    public SimpleHealthBar attackBar;
    public static bool enemyIsDead;
    public bool canAttack = true;
    //public Camera mainCamera;
    public bool attacked = true;
    public AudioClip[] audioClip;

    GameObject temp;
    GameObject NewSphere;
    Player player;
    NumberSpawner floatingText;
    Animator animator;

    int rnd;
    string[] animations = {"Attack1", "Attack3", "Attack4", "Attack5", "Attack7" };
    public bool canUpdate = true;
    float TimerForAttackBar = 2.5f;
    static float maxTimerForAttakBar = 2.5f;
    
    bool counterAttacked = false;



    public bool isTriggered;


    void Start()
    {       
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<NumberSpawner>();
        //transform.rotation = Quaternion.Inverse(playerController.transform.rotation);
    }


    public void CounterAttack()
    {

        animator.Play("Reaction");
        counterAttacked = true;
        Destroy(NewSphere);
        canUpdate = true;
        //canAttack = true;
        //attacked = true;
    }


    public void DMG(float AttackValue)
    {
        if (!enemyIsDead)
        {
            currHP -= AttackValue;
            GetComponentInChildren<AudioSource>().PlayOneShot(audioClip[0]);
            floatingText.Spawn(AttackValue);
            
            player.attacked = true;

            hPBar.UpdateBar(currHP, maxHp);
            isDead();

            //attacked = true;
            canUpdate = true;
            TimerForAttackBar = maxTimerForAttakBar;



        }
    }

    public void HitAnimation()
    {
        
        animator.SetFloat("AttackRange", Random.Range(0, 4));
        rnd = (int)Mathf.Round(animator.GetFloat("AttackRange"));

        if (rnd >= 0 && rnd <= 4)
            temp = rightHand;
        else if (rnd >= 5 && rnd <= 5)
            temp = leftHand;
        else if (rnd >= 6 && rnd <= 6)
            temp = leftFoot;

        NewSphere = Instantiate(sphere, temp.transform.position, Quaternion.identity);
        NewSphere.transform.SetParent(temp.transform);
        
        
        Destroy(NewSphere, animator.GetCurrentAnimatorClipInfo(0).Length + animator.GetNextAnimatorClipInfo(0).Length);
        counterAttacked = false;
        //canAttack = false;
        //attacked = false;
    }



    void SetDMG()
    {
        
        if (!counterAttacked && !player.Dodge() && isTriggered)
        {
            player.SetDMG(15);
            player.GetComponentInChildren<Camera>().GetComponent<Animator>().Play("Hit");
            GetComponentInChildren<AudioSource>().PlayOneShot(audioClip[1]);
        }
        canUpdate = true;
        Destroy(NewSphere);
        //canAttack = true;
        //attacked = true;
        TimerForAttackBar = maxTimerForAttakBar;
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



    bool DeadAnimation()
    {

         GetComponentInChildren<AudioSource>().PlayOneShot(audioClip[2]);
         animator.Play("Won");
         return true;
            
    }
    void AttackBarUpdate()
    {
        TimerForAttackBar -= Time.deltaTime;
        
        attackBar.UpdateBar(TimerForAttackBar, maxTimerForAttakBar);
        if (TimerForAttackBar <= 0)
        {
            //canAttack = true;
            canUpdate = false;
            //animator.SetTrigger("JumpForward");
        }
    }

    /*
    void Jump()
    {
        float chance = 50f;
        if (System.Math.Round(Time.timeSinceLevelLoad, 2) % 5 == 0 && chance >= Random.Range(0f, 100f))
        {
            counterAttacked = false;
            canUpdate = false;
            canAttack = false;
            attacked = true;
            animator.Play("JumpBack");
        }
    }
    */



    void FixedUpdate()
    {
        //Jump();

        if (isDead())
        {
            

        }
        else if (player.isDead)
        {
        if (!DeadAnimation())
            DeadAnimation();

            
        }
        else if (canUpdate)
        {
            AttackBarUpdate();
        }
        /*
        else if (canAttack)
        {

            HitAnimation();
        }
        */
        

       // Debug.Log("attacked " + attacked);
    }

    private void OnDestroy()
    {
        enemyIsDead = true;
        
    }




}