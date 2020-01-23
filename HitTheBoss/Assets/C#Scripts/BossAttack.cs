﻿using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftFoot;
    public GameObject sphere;

    string[] animations = { "Attack1", "Attack12", "Attack3", "Attack4", "Attack5", "Attack6", "Attack7" }; //All Boss animations
    public void Hit()
    {
        GameObject temp = new GameObject() ;
        int rnd = Random.Range(0, animations.Length);
        Vector3 positionOfSphere = new Vector3(0, 0, 0);

        //Get position for sphere
      //  if (rnd >= 0 && rnd <= 1)
            temp = rightHand;
        //else if (rnd >= 2 && rnd <= 2)
        //    temp = LeftFoot;

        GameObject NewSphere = Instantiate(sphere, temp.transform.position, Quaternion.identity);
        NewSphere.transform.SetParent(temp.transform);
        GetComponent<Animator>().Play(animations[rnd]);
        StartCoroutine(DeleteAfterSomeTime(1.0f, NewSphere));
    }

    IEnumerator DeleteAfterSomeTime(float time, GameObject newSphere)
    {
        yield return new WaitForSeconds(time);
        Destroy(newSphere);
    }
   
}
