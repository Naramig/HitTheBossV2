using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractTrigger")
        {
            Debug.Log("interact");
            GameObject newEnemy = Instantiate(enemy,transform.position,Quaternion.LookRotation(-player.transform.position));
        }
    }
}
