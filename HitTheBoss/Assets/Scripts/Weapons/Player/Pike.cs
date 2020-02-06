using UnityEngine;

public class Pike : MonoBehaviour, IWeapon
{
    public PlayerController playerController;
    Vector3 startPos;
    Quaternion startRot;
    public GameObject hitGameObject; 


    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        startPos = transform.position;
        startRot = transform.rotation;
    }
    public void DoDamage(Collider other)
    {
        GetComponentInParent<HandController>().speared = true;
        other.GetComponent<IBodyPart>().GetDMG(other.GetComponent<StaminaController>());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Armor" || other.tag == "BodyPart")
        {
            DoDamage(other);
        }

    }







}
