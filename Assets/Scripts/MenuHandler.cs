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
    //[SerializeField] private GameObject MenuButton;


    public bool isPlaying;

    void Start()
    {
        isPlaying = false;
    }

    private void Update()
    {
        if (isPlaying == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(isPlaying == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown("e"))
        {
            isPlaying = false;
            MenuPanelOn();
        }
    }

    public void MenuPanelOn()
    {
        Time.timeScale = 0;

        MenuPanel.SetActive(true);
        healthBar.SetActive(false);
        staminaBar.SetActive(false);
        manaBar.SetActive(false);
        miniMap.SetActive(false);
       // MenuButton.SetActive(false);
    }

    public void MenuPanelOff()
    {
        isPlaying = true;

        Time.timeScale = 1;

        MenuPanel.SetActive(false);
        healthBar.SetActive(true);
        staminaBar.SetActive(true);
        manaBar.SetActive(true);
        miniMap.SetActive(true);
       // MenuButton.SetActive(true);
    }
    public void KeyBindsSettingsOn()
    {
        keyBindsPanel.SetActive(true);
    }

    public void KeyBindsSettingsOff()
    {
        keyBindsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
