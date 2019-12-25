using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    public int HP = 100;
    public Text pts;
    // Start is called before the first frame update
    void Start()
    {
        pts.text = HP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        pts.text = HP.ToString();

    }
}
