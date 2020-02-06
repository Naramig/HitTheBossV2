using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    public SimpleHealthBar healthBar;
    public float maxHP;
    public float CurrentHP;
    float dmg;

  


    public bool isDead()
    {

        if (CurrentHP <= 0)
        {
            //animator.Play("Dying");
            Destroy(gameObject, 3);

            return true;
        }
        else
            return false;
    }



    private void Update()
    {
        if (CurrentHP < healthBar.targetFill)
        {
            CurrentHP -= Time.fixedDeltaTime;
            healthBar.UpdateBar(CurrentHP, maxHP);
            
        }

    }

}
