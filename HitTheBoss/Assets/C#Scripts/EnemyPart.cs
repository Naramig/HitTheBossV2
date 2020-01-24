using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    new AudioSource audio;
    public AudioClip hitAudio;
    public string animationName;
    Enemy enemy;
    Player playerController;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<Player>();
        audio = FindObjectOfType<AudioSource>();
        enemy = FindObjectOfType<Enemy>();
        animator = enemy.GetComponent<Animator>();
    }
    public void DMG()
    {
        float dmg = Mathf.CeilToInt(playerController.attackMod * 2);

        enemy.DmgToBoss(dmg);
        if (!enemy.enemyIsDead)
        {
            audio.clip = hitAudio;
            animator.Play(animationName);
            audio.Play();
        }
        Debug.Log("HERE");

    }

}
