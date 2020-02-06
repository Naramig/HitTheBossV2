using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPController : MonoBehaviour
{
    SimpleHealthBar healthBar;
    public float maxHP;
    public float CurrentHP;
    float dmg;

    public void HPUpdate()
    {
        if (CurrentHP > CurrentHP - dmg)
        {
            CurrentHP -= Time.fixedDeltaTime;
            healthBar.UpdateBar(CurrentHP, maxHP);
        }

    }

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
        HPUpdate();
    }

}
