using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    AudioSource audio;
    public AudioClip hitAudio;
    public string animationName;
    Enemy enemy;
    Player player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        audio = FindObjectOfType<AudioSource>();
        enemy = GetComponentInParent<Enemy>();
        animator = enemy.GetComponent<Animator>();
    }
    public void DMG()
    {
        float dmg = Mathf.CeilToInt(player.attackMod * 3);

        enemy.DMG(dmg);
        if (!enemy.isDead())
        {
            audio.clip = hitAudio;
            animator.Play(animationName);
            audio.Play();
        }
        

    }

}
