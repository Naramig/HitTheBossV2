using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftFoot;
    public GameObject leftHand;

    public GameObject sphere;
    GameObject temp;

    string[] animations = { "Attack1", "Attack2", "Attack3", "Attack4", "Attack5", "Attack6", "Attack7" }; //All Boss animations
    public void Hit()
    {

        int rnd = Random.Range(0, animations.Length);
        Vector3 positionOfSphere = new Vector3(0, 0, 0);

        //Get position for sphere
        if (rnd >= 0 && rnd <= 4)
            temp = rightHand;
        else if (rnd >= 5 && rnd <= 5)
            temp = leftHand;
        else if (rnd >= 6 && rnd <= 6)
            temp = leftFoot;

        GameObject NewSphere = Instantiate(sphere, temp.transform.position, Quaternion.identity);
        NewSphere.transform.SetParent(temp.transform);
        GetComponent<Animator>().Play(animations[rnd]);
        Destroy(NewSphere,1);
    }

}
