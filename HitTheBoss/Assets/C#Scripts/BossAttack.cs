using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject RightHand;
    public GameObject LeftFoot;

    public GameObject Sphere;

    string[] animations = { "RightHand1", "RightHand2", "rightLeg" }; //All Boss animations
    public void Hit()
    {
        int rnd = Random.Range(0, animations.Length - 1);
        Vector3 positionOfSphere = new Vector3(0, 0, 0);

        //Get position for sphere
        if (rnd >= 0 && rnd <= 1)
            positionOfSphere = RightHand.transform.position;
        else if (rnd >= 2 && rnd <= 2)
            positionOfSphere = LeftFoot.transform.position;

        GameObject NewSphere = Instantiate(Sphere, positionOfSphere, Quaternion.identity);
        GetComponent<Animator>().Play(animations[rnd]);
        StartCoroutine(DeleteAfterSomeTime(0.7f, NewSphere));
    }

    IEnumerator DeleteAfterSomeTime(float time, GameObject NewSphere)
    {
        yield return new WaitForSeconds(time);
        Destroy(NewSphere);
    }
   
}
