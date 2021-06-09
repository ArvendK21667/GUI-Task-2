using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthManagers : MonoBehaviour
{

    [SerializeField] private GameObject deathscreenPanel;
    public float health;
    public float maxhealth;
    public Image healthbar;
    public TextMeshProUGUI number;

    bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthbar.fillAmount = 1;

        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            health = health - 5;
            if (health < 0)
            {
                health = 0;
            }
            float fraction = health / maxhealth;
            healthbar.fillAmount = fraction;
            number.text = health + "/" + maxhealth;
        }

        if (Input.GetKeyDown("x"))
        {
            health = health + 5;
            if (health > 100)
            {
                health = 100;
            }
            float fraction = health / maxhealth;
            healthbar.fillAmount = fraction;
            number.text = health + "/" + maxhealth;
        }

        if(health <= 0)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }

        if( isAlive == false)
        {
            deathscreenPanel.SetActive(true);
            Time.timeScale = 0;

            //Want to make it spawn in a random.range location 
        }
        else
        {
            deathscreenPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
