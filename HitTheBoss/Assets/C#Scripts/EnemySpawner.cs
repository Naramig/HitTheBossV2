using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    
    private void Start()
    {
        enemy.transform.position = new Vector3(0, 0.24f, 1.46f);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger" )
        {
            
            GameObject newEnemy = Instantiate(enemy,transform.position, Quaternion.identity);
        }
    }
    */
    private void FixedUpdate()
    {
        if (!Enemy.enemyIsDead) return;
        
        Enemy.enemyIsDead = false;
        Instantiate(enemy, enemy.transform.position, Quaternion.identity);
    }
}
