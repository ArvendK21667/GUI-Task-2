using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManagers : MonoBehaviour
{
    [SerializeField] private GameObject DeathscreenPanel;
    [SerializeField] private GameObject HealthBar;
    [SerializeField] private GameObject StaminaBar;
    [SerializeField] private GameObject ManaBar;
    [SerializeField] private GameObject MiniMap;
    [SerializeField] private GameObject CrossHair;
    [SerializeField] private GameObject DamageIndicator;
    [SerializeField] private GameObject Character;


    //[SerializeField] private GameObject MenuButton;
    public float health;
    public float maxhealth;
    public Image healthbar;
    public TextMeshProUGUI number;

    public float HealthTimeToRegen = 3.0f;
    public float HealthRegenTimer = 0.0f;

    public float time = 0.3f;
    public float count = 0;

    public StaminaManager staminamanagerScript;
    public ManaManager manamanagerScript;
    public ThirdPersonMovement thirdpersonmovementScript;

    bool isAlive;
    bool didtakeDamage;

    // Start is called before the first frame update
    public void Start()
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
            health = health - 5; //reduce t hitpoints when pressing z
            didtakeDamage = true;

            if (health < 0) //prevents negative health
            {
                health = 0;

            }
            float fraction = health / maxhealth;    // makes it a fraction
            healthbar.fillAmount = fraction;        // changes fillamount on bar
            number.text = health + "/" + maxhealth; // chnages number on text for bar
        }

        if (didtakeDamage == true) //when taking damage doe reset time method and make it not taking damage
        {
            ResetHealthRegenTimer();  //do this method when taking damage
            StartCoroutine(DamageIndicatorShow(1)); //do this method when taking damage
            didtakeDamage = false; //set it back to false

        }
        if (didtakeDamage == false) //when not taking damage do Regen method
        {
            HealthRegen(); //do this method when not taking damage
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            DeathScreenRespawn();
            HealthBar.SetActive(false);   //Deactivates HealthBar
            StaminaBar.SetActive(false);  //Deactivates Stamina Bar
            ManaBar.SetActive(false);     //Deactivates Mana bar
            MiniMap.SetActive(false);     //Deactivates Mini-map
            CrossHair.SetActive(false);   //Deactivates Crosshair
            Time.timeScale = 0;
            // MenuButton.SetActive(false);


            //Want to make it spawn in a random.range location 
        }
        else //otherwise don't open death panel, remove stat bars & map nor pause the time. Also remove the lock on cursor.
        {
            DeathscreenPanel.SetActive(false);
            HealthBar.SetActive(true);   //Activates HealthBar
            StaminaBar.SetActive(true);  //Activates Stamina Bar
            ManaBar.SetActive(true);     //Activates Mana bar
            MiniMap.SetActive(true);     //Activates Mini-map
            CrossHair.SetActive(true);   //Activates Crosshair
            //MenuButton.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
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

    public void DamageIndicatorMethodOn() //damage indicator on
    {
        DamageIndicator.SetActive(true);
    }
    public void DamageIndicatorMethodOff() //damage indicator off
    {
        DamageIndicator.SetActive(false);
    }

    private IEnumerator DamageIndicatorShow(float _time) //turns damage indicator on. In 0.3 seconds turns it off again.
    {
        _time = Time.deltaTime; //_time to equal real time

        DamageIndicatorMethodOn(); //damage indicator on Method

        yield return new WaitForSeconds(_time); //Waiting for (_time) seconds (0.3 real seconds)

        DamageIndicatorMethodOff(); //damage indicator off Method
    }
    public void DeathScreenRespawn() //Pops up Death Screen panel
    {
        DeathscreenPanel.SetActive(true);
    }

    public void Respawn() //Does respawn Method
    {
        Cursor.lockState = CursorLockMode.None; //Unlocks Cursor
        DeathscreenPanel.SetActive(false); //Disables Death Screen
        Character.transform.position = new Vector3(-2, 0, -10); //respawns the charecter
        Start(); // Restarts the Start Method
        manamanagerScript.Start(); // Restarts the Start Method
        staminamanagerScript.Start(); // Restarts the Start Method
        thirdpersonmovementScript.Start(); // Restarts the Start Method
        HealthBar.SetActive(true);   //Activates HealthBar
        StaminaBar.SetActive(true);  //Activates Stamina Bar
        ManaBar.SetActive(true);     //Activates Mana bar
        MiniMap.SetActive(true);     //Activates Mini-map
        CrossHair.SetActive(true);   //Activates Crosshair
        Cursor.lockState = CursorLockMode.Locked; //Locks Cursor
        DamageIndicatorMethodOff(); //turns off damage indicator from death
        Time.timeScale = 1; //unPauses times
    }
}
