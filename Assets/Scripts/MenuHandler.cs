using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject keyBindsPanel;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject staminaBar;
    [SerializeField] private GameObject manaBar;
    [SerializeField] private GameObject miniMap;
    [SerializeField] private GameObject CrossHair;

    public HealthManagers healthmanagersScript;

    //[SerializeField] private GameObject MenuButton;


    public bool isPlaying;

    void Start()
    {
        isPlaying = false; //set to not playing game and on menu only
    }


    private void Update()
    {
        if (Input.GetKeyDown("e")) //open the options panel 
        {
            isPlaying = false;
            MenuPanelOn();
        }
    }

    public void MenuPanelOn()
    {
        isPlaying = false; //not playing game

        Time.timeScale = 0; //pause time

        Cursor.lockState = CursorLockMode.None; //unlock cursor

        MenuPanel.SetActive(true);    //Activates Menu Panel
        healthBar.SetActive(false);   //Deactivates HealthBar
        staminaBar.SetActive(false);  //Deactivates Stamina Bar
        manaBar.SetActive(false);     //Deactivates Mana bar
        miniMap.SetActive(false);     //Deactivates Mini-map
        CrossHair.SetActive(false);   //Deactivates Crosshair
        // MenuButton.SetActive(false);
    }

    public void MenuPanelOff()
    {
        isPlaying = true; //playing game

        Time.timeScale = 1; //unpause time

        Cursor.lockState = CursorLockMode.Locked; //lock cursor

        MenuPanel.SetActive(false);  //Deactivates Menu Panel
        healthBar.SetActive(true);   //Activates HealthBar
        staminaBar.SetActive(true);  //Activates Stamina Bar
        manaBar.SetActive(true);     //Activates Mana bar
        miniMap.SetActive(true);     //Activates Mini-map
        CrossHair.SetActive(true);   //Activates Crosshair
        // MenuButton.SetActive(true);
    }
    public void KeyBindsSettingsOn()
    {
        keyBindsPanel.SetActive(true); //Activates KeyBinds Panel
        MenuPanel.SetActive(false);    //Deactivates Menu Panel
    }

    public void KeyBindsSettingsOff()
    {
        keyBindsPanel.SetActive(false); //Deactivates KeyBinds Panel
        MenuPanel.SetActive(true);      //Activates Menu Panel
    }

    public void QuitGame() //Quit Method
    {
        Application.Quit();
    }
}
