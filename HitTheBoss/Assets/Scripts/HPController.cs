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
        if (CurrentHP < 0)
        {
            Debug.Log("Dead");
        }
    }


    private void Update()
    {
        HPUpdate();
    }

}
