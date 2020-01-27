using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    AudioSource audio;
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
        float dmg = Mathf.CeilToInt(playerController.attackMod * 3);

        enemy.DMG(dmg);
        if (!enemy.isDead())
        {
            audio.clip = hitAudio;
            animator.Play(animationName);
            audio.Play();
        }
        

    }

}
