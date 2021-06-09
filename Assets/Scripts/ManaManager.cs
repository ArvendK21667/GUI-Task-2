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
    public float counter = 0;
    public float time = 5;

    // Start is called before the first frame update
    void Start()
    {
        maxMana = 100f;
        mana = 0f;
        manaBar.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //if (counter < time)
        //{
        //    counter += Time.deltaTime; // making it 5 real seconds long 

        //    float progress = Mathf.Clamp01(counter / time); //to show progress in decimals

        //    manaBar.fillAmount = progress; //fills the progress bar on the loadin bar
        //    progressText.text = progress * 100f + "%"; //changes the text and multiply it by 100 to make it from decimal to % and add % symbol

        //}

        if (Input.GetKeyDown("p"))
        {
            mana += 10f;
            if (mana > maxMana)
            {
                mana = 100;
            }
            float fraction = mana / maxMana;
            manaBar.fillAmount = fraction;
            progressText.text = fraction * 100 + "%";

        }

       if (mana == 100)
        {
            if (Input.GetKeyDown("l"))
            {

                mana = 0;

                float fraction = mana / maxMana;
                manaBar.fillAmount = fraction;
                progressText.text = fraction * 100 + "%";
            }
        }
            
    }
}
