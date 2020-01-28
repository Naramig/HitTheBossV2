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
    public float currHP;
    public float maxHp;
    public SimpleHealthBar hPBar;
    public SimpleHealthBar attackBar;
    public static bool enemyIsDead;
    public bool canAttack = true;
    public Camera mainCamera;
    public bool attacked = false;


    GameObject temp;
    GameObject NewSphere;
    Player playerController;
    NumberSpawner floatingText;
    Animator animator;
    

    string[] animations = {"Attack1", "Attack3", "Attack4", "Attack5", "Attack7" };
    bool canUpdate = true;
    float TimerForAttackBar = 5f;
    static float maxTimerForAttakBar = 5f;
    
    bool counterAttacked = false;

    


    void Start()
    {
        enemyIsDead = false;
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<Player>();
        floatingText = FindObjectOfType<NumberSpawner>();
        //transform.rotation = Quaternion.Inverse(playerController.transform.rotation);
        
        
    }


    public void CounterAttack()
    {

        animator.Play("Reaction");
        counterAttacked = true;
        Destroy(NewSphere);
        canUpdate = true;
        canAttack = true;
        attacked = false;
    }


    public void DMG(float AttackValue)
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

        if (rnd >= 0 && rnd <= 4)
            temp = rightHand;
        else if (rnd >= 5 && rnd <= 5)
            temp = leftHand;
        else if (rnd >= 6 && rnd <= 6)
            temp = leftFoot;

        NewSphere = Instantiate(sphere, temp.transform.position, Quaternion.identity);
        NewSphere.transform.SetParent(temp.transform);
        GetComponent<Animator>().Play(animations[rnd]);
        Destroy(NewSphere, animations[rnd].Length);
        counterAttacked = false;
        TimerForAttackBar = maxTimerForAttakBar;
        canAttack = false;
        attacked = true;
    }



    void SetDMG()
    {
        
        if (!counterAttacked && !playerController.Dodge())
        {
            playerController.SetDMG(15);
            mainCamera.GetComponent<Animator>().Play("Hit");
            
        }
        canUpdate = true;
        Destroy(NewSphere);
        canAttack = true;
        attacked = false;
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
            canAttack = true;
            canUpdate = false;
        }
    }

    void FixedUpdate()
    {
       
        if (isDead())
        {
            

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
        
        else if (canAttack)
        {

            HitAnimation();
        }
        

    }

    private void OnDestroy()
    {
        enemyIsDead = true;
    }




}