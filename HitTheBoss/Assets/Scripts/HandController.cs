using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject ItemInHand { get; private set; }
    StaminaController stamina;
    public bool speared = false;
    float canSpearedTimer = 0.2f;
    public PlayerController playerController;
    Vector3 startPos;
    Quaternion startRot;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void SpearAnimation()
    {
        if (speared)
        {
            canSpearedTimer -= Time.deltaTime;
            if (canSpearedTimer > 0)
            {
                //GetComponentInChildren<Animator>().Play("Hit");
                transform.rotation = Quaternion.LookRotation(playerController.mousePos - transform.position);
                transform.position = Vector3.Lerp(transform.position, playerController.mousePos + new Vector3(0, 0, 0.5f), 0.2f);
            }

            if (canSpearedTimer <= -0.2f)
            {
                speared = false;
            }
            if (canSpearedTimer <= 0)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, startRot, 0.2f);
                transform.position = Vector3.Lerp(transform.position, startPos, 0.2f);
            }

        }
        if (!speared)
        {
            canSpearedTimer = 0.2f;

        }
    }
    private void Update()
    {
        SpearAnimation();
    }

    /*
    private void MoveItem()
    {
        ItemInHand.transform.position = transform.position;
        ItemInHand.transform.up = transform.up;
    }

    private bool IsHasItemInHand()
    {
        if (ItemInHand) return true;
        
        return false;
    }

    public bool UseItem()
    {
        if (ItemInHand.GetComponent<IWeapon>() != null)
        {
            IWeapon weapon = ItemInHand.GetComponent<IWeapon>();
            
            stamina.DecreaseStamina();
            return true;
        }
        return false;
    }



    void FixedUpdate()
    {
        if (IsHasItemInHand())
        {
            MoveItem();
        }

    }
    */
}
