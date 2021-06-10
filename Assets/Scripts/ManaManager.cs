using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ManaManager : MonoBehaviour
{

    public float mana;
    public float maxMana;
    public Image manaBar;
    public TextMeshProUGUI progressText;
    public float ManaTimeToRegen = 15.0f;
    public float ManaRegenTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        maxMana = 100f;
        mana = 0f;
        manaBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if(mana < maxMana)
        {
            
              mana = Mathf.Clamp(mana + 0.02f + (Time.deltaTime), 0.0f, maxMana);
            

            float fraction = mana / maxMana;
            manaBar.fillAmount = fraction;
            progressText.text = fraction * 100 + "%";
        }

        if (mana >= maxMana)
        {
            mana = 100;

            if (Input.GetKeyDown("l"))
            {

                mana = 0;

                float fraction = mana / maxMana;
                manaBar.fillAmount = fraction;
                progressText.text = fraction * 100 + "%";

                ManaRegenTimer = 0.0f;
            }
        }
            
    }
}
