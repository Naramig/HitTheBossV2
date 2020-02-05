using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    SimpleHealthBar staminaBar;
    public float maxStamina;
    public float CurrentStamina { get; private set; }

    public void DecreaseStamina()
    {
        CurrentStamina = 0;
    }

    public void IncreaseStamina()
    {
        
    }

    public void RestoreStamina()
    {

    }

    public void StaminaUpdate()
    {
        CurrentStamina += Time.fixedDeltaTime;
        staminaBar.UpdateBar(CurrentStamina,maxStamina);
        if (CurrentStamina > maxStamina)
        {
            staminaBar.colorMode = SimpleHealthBar.ColorMode.Single;
            staminaBar.UpdateColor(Color.yellow);
            CurrentStamina = maxStamina;
        }
        if (CurrentStamina <= 0)
        {
            CurrentStamina = 0;
        }
        else
        {
            staminaBar.colorMode = SimpleHealthBar.ColorMode.Gradient;
        }
    }


    private void FixedUpdate()
    {
        StaminaUpdate();
    }
}
