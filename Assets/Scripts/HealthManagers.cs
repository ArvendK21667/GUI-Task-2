using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManagers : MonoBehaviour
{

    [SerializeField] private GameObject deathscreenPanel;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject StaminaBar;
    [SerializeField] private GameObject ManaBar;
    [SerializeField] private GameObject MiniMap;
    //[SerializeField] private GameObject MenuButton;
    public float health;
    public float maxhealth;
    public Image healthbar;
    public TextMeshProUGUI number;

    public float HealthTimeToRegen = 3.0f;
    public float HealthRegenTimer = 0.0f;

    bool isAlive;
    bool didtakeDamage;

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = 100;
        health = maxhealth;
        healthbar.fillAmount = 1;

        isAlive = true;
        didtakeDamage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            health = health - 5;
            didtakeDamage = true; 
            
            if (health < 0)
            {
                health = 0;
            }
            float fraction = health / maxhealth;    // makes it a fraction
            healthbar.fillAmount = fraction;        // changes fillamount on bar
            number.text = health + "/" + maxhealth; // chnages number on text for bar
        }

        if(didtakeDamage == true) //when taking damage doe reset time method and make it not taking damage
        {
            ResetHealthRegenTimer();
            didtakeDamage = false;
        }
        if(didtakeDamage == false) //when not taking damage do Regen method
        {
            HealthRegen();
        }

        //if(health < maxhealth) //if health is lower than max health do regen method
        //{
        //    HealthRegen();  //I think it is not needed
        //}

        if (health <= 0) //if health is 0 then it is DEAD
        {
            isAlive = false;
        }
        else //otherwise its alive
        {
            isAlive = true;
        }

        if (isAlive == false) //if DEAD, bring death panel, remove stat bars & map and pauses time
        {
            deathscreenPanel.SetActive(true);
            HealthBar.SetActive(false);
            StaminaBar.SetActive(false);
            ManaBar.SetActive(false);
            MiniMap.SetActive(false);
           // MenuButton.SetActive(false);
            Time.timeScale = 0;

            //Want to make it spawn in a random.range location 
        }
        else //otherwise don't open death panel, remove stat bars & map nor pause the time
        {
            deathscreenPanel.SetActive(false);
            HealthBar.SetActive(true);
            StaminaBar.SetActive(true);
            ManaBar.SetActive(true);
            MiniMap.SetActive(true);
            //MenuButton.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void HealthRegen()
    {
        HealthRegenTimer += Time.deltaTime; //sets float amount based on real time seconds
        if (health < maxhealth) //increastes health when not movin
        {

            if (HealthRegenTimer >= 3.0f) //gives a time of 1.5 seconds before regen starts
            {
                health = Mathf.Clamp(health + 0.0065f + (Time.deltaTime), 0.0f, maxhealth);
                //Adds Health by Health Regen     // clamps the value of health from 0 to max;
            }
        }
        if (health >= maxhealth) //makes it not go above max amount of health
        {
            health = 100;
        }
        float fraction = health / maxhealth;    // makes it a fraction
        healthbar.fillAmount = fraction;        // changes fillamount on bar
        number.text = health + "/" + maxhealth; // chnages number on text for bar
    }

    public void ResetHealthRegenTimer() //resets regentimer method
    {
        HealthRegenTimer = 0f;
    }
} 
