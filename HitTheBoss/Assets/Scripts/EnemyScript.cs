using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public float maxHP = 100;
    public float currentHP = 100;

    public SimpleHealthBar healthBar;

    public GameObject player;
    PlayerScript playerScript;
    bool canHit = true;

    float timeToStartHitting = 6.0f;
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }
    public void DMG(float dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            this.GetComponent<Animator>().Play("Dead");
        }
        healthBar.UpdateBar(currentHP, maxHP);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (canHit && currentHP > 0)
        {
            StartCoroutine(hitThePlayer(timeToStartHitting));
            canHit = false;
        }
    }

    IEnumerator hitThePlayer(float time)
    {
        playerScript.DMG(20);
        this.GetComponent<Animator>().Play("boxing");
        yield return new WaitForSeconds(time);
        canHit = true;
    }
}
