using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            
            GameObject newEnemy = Instantiate(enemy,transform.position, Quaternion.identity);
        }
    }
}
