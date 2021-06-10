using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StaminaManager : MonoBehaviour
{
    public float stamina;
    public float maxStamina;
    public Image staminaBar;
    public TextMeshProUGUI number;

    public float StaminaTimeToRegen = 1.5f;
    public float StaminaRegenTimer = 0.0f;

    public bool canRegen;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina; //current stamina equa; max amount of stamina
        staminaBar.fillAmount = 1; //starts with full bar
    }

    public void StaminaReduction()
    {
        stamina -= .4f;  // reduces some stamina  
        if (stamina < 0)  //makes it not go below 0
        {
            stamina = 0;
        }
        float fraction = stamina / maxStamina;     // makes it a fraction
        staminaBar.fillAmount = fraction;          // changes fillamount on bar
        number.text = stamina + "/" + maxStamina;  // chnages number on text for bar
    }

    public void StaminaReductionByJump()
    {
        stamina -= 20f; //reduces 20 stamina once I press jump
        if (stamina < 0) //makes it not go below 0
        {
            stamina = 0;
        }
        float fraction = stamina / maxStamina;      // makes it a fraction
        staminaBar.fillAmount = fraction;           // changes fillamount on bar
        number.text = stamina + "/" + maxStamina;   // chnages number on text for bar
    }
    public void StaminaIncrease()
    {
        StaminaRegenTimer += Time.deltaTime; //sets float amount based on real time seconds
        if (stamina < maxStamina)  //increastes stamina when not moving
        {
            if (StaminaRegenTimer >= 1.5f) //gives a time of 1.5 seconds before regen starts
            {
                stamina = Mathf.Clamp(stamina + 0.65f + (Time.deltaTime), 0.0f, maxStamina);
               //Adds Stamina by Stamina by regen     // clamps the value of stamina from 0 to max;
            }
        }
        if (stamina >= maxStamina) //makes it not go above max amount of stamina
        {
            stamina = 1000;
        }
        float fraction = stamina / maxStamina;     // makes it a fraction
        staminaBar.fillAmount = fraction;          // changes fillamount on bar
        number.text = stamina + "/" + maxStamina;  // chnages number on text for bar
    }

    public void ResetStaminaRegenTimer() //resets regentimer method
    {
        StaminaRegenTimer = 0f;
    }
}
