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
    public void Start()
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
            mana = Mathf.Clamp(mana + 0.02f + (Time.deltaTime), 0.0f, maxMana); //increase the mana over time

            float fraction = mana / maxMana;          // makes it a fraction
            manaBar.fillAmount = fraction;            // changes fillamount on bar
            progressText.text = fraction * 100 + "%"; // chnages number on text for bar
        }

        if (mana >= maxMana) //if is over 100 make it 100
        {
            mana = 100; 

            if (Input.GetKeyDown("l")) //use power and reduce to 0
            {
                mana = 0; 

                float fraction = mana / maxMana;          // makes it a fraction
                manaBar.fillAmount = fraction;            // changes fillamount on bar
                progressText.text = fraction * 100 + "%"; // chnages number on text for bar

                ManaRegenTimer = 0.0f;
            }
        }
            
    }
}
