using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TextMesh text;
    public GameObject floatingText;
    GameObject newFloatingText;
    Player playerController;

    void Start()
    {
        playerController = FindObjectOfType<Player>();
    }

    public void Spawn(float dmg, GameObject parent)
    {
        text.text = dmg.ToString();
        newFloatingText = Instantiate(floatingText, playerController.mousePos + new Vector3(0, Random.Range(0.2f, 0.4f), 0), Quaternion.identity, parent.transform);
        Destroy(newFloatingText, 2);
    }

    void Update()
    {
        
    }
}
