using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyLilNumber : MonoBehaviour
{
    float flyTimer = 2;
    bool fly;
    Vector3 randomRange;
    private void Start()
    {
         randomRange = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4));
    }
    private void Update()
    {

        if (fly)
        {
            Debug.Log(flyTimer);
            flyTimer -= Time.deltaTime;
            
            transform.position = Vector3.Lerp(transform.position, randomRange, Time.deltaTime);

            if (flyTimer <= 0)
            {
                fly = false;
            }
        }
        if (!fly)
        {
            flyTimer = 2;
            fly = true;
        }


    }

}
