using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject keyBindsPanel;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject staminaBar;
    [SerializeField] private GameObject manaBar;
    [SerializeField] private GameObject miniMap;
    [SerializeField] private GameObject keyBindsButton;
    

    public void KeyBindsSettingsOn()
    {
        Time.timeScale = 0;

        keyBindsPanel.SetActive(true);
        healthBar.SetActive(false);
        staminaBar.SetActive(false);
        manaBar.SetActive(false);
        miniMap.SetActive(false);
        keyBindsButton.SetActive(false);
    }

    public void KeyBindsSettingsOff()
    {
        Time.timeScale = 1;

        keyBindsPanel.SetActive(false);
        healthBar.SetActive(true);
        staminaBar.SetActive(true);
        manaBar.SetActive(true);
        miniMap.SetActive(true);
        keyBindsButton.SetActive(true);
    }
}
