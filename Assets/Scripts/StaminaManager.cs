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

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
        staminaBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            stamina = stamina - 25;
            if (stamina < 0)
            {
                stamina = 0;
            }
            float fraction = stamina / maxStamina;
            staminaBar.fillAmount = fraction;
            number.text = stamina + "/" + maxStamina;
        }

        if (Input.GetKeyDown("t"))
        {
            stamina = stamina + 25;
            if (stamina > 1000)
            {
                stamina = 1000;
            }
            float fraction = stamina / maxStamina;
            staminaBar.fillAmount = fraction;
            number.text = stamina + "/" + maxStamina;
        }
    }

    //public void StaminaReduction()
    //{
    //    stamina -= .4f;
    //    if (stamina < 0)
    //    {
    //        stamina = 0;
    //    }
    //    float fraction = stamina / maxStamina;
    //    staminaBar.fillAmount = fraction;
    //    number.text = stamina + "/" + maxStamina;
    //}

    //public void StaminaIncrease()
    //{
    //    stamina += 1f;
    //    if (stamina > 1000)
    //    {
    //        stamina = 1000;
    //    }
    //    float fraction = stamina / maxStamina;
    //    staminaBar.fillAmount = fraction;
    //    number.text = stamina + "/" + maxStamina;
    //}
}
