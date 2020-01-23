using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject RightHand;
    public GameObject LeftFoot;


    
    public GameObject Sphere;


    string[] animations = { "RightHand", "RightHand2", "rightLeg" }; //All Boss animations
    public void Hit()
    {
        GameObject temp = new GameObject() ;
        int rnd = 2;
        //int rnd = Random.Range(0, animations.Length);
        Vector3 positionOfSphere = new Vector3(0, 0, 0);

        //Get position for sphere
        if (rnd >= 0 && rnd <= 1)
            temp = RightHand;
        else if (rnd >= 2 && rnd <= 2)
            temp = LeftFoot;

        GameObject NewSphere = Instantiate(Sphere, temp.transform.position, Quaternion.identity);
        NewSphere.transform.SetParent(temp.transform);
        GetComponent<Animator>().Play(animations[rnd]);
        StartCoroutine(DeleteAfterSomeTime(1.0f, NewSphere));
    }

    IEnumerator DeleteAfterSomeTime(float time, GameObject NewSphere)
    {
        yield return new WaitForSeconds(time);
        Destroy(NewSphere);

    }
   
}
