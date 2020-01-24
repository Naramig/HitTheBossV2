using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSpawner : MonoBehaviour
{
    TextMesh text;
    public GameObject floatingText;
    
    Player playerController;

    void Start()
    {
        
        text = floatingText.GetComponent<TextMesh>();
        playerController = FindObjectOfType<Player>();
    }

    public void Spawn(float dmg/*, GameObject parent*/)
    {
        text.text = dmg.ToString();
        GameObject newFloatingText = Instantiate(floatingText, playerController.mousePos + new Vector3(0, Random.Range(0.2f, 0.4f), 0), Quaternion.identity, this.transform);
        Destroy(newFloatingText, 2);
    }

    void Update()
    {
        
    }
}
