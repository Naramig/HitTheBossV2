using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{

    void moveOn()
    {
        transform.position -= new Vector3(0,0,1.5f);
       
    }
    void moveOff()
    {
        Debug.Log("move");
        transform.position += new Vector3(0, 0, 1.5f);
    }

}
