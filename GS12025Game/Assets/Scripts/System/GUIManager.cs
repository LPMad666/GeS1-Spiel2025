using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{

    public PlayerStats playerStats; // Referenz zum PlayerStats-Skript
    public PlayerShooting shooting; // Referenz zum PlayerShooting-Skript
    public TMP_Text healthText; // Referenz zum UI-Text für die Gesundheit
    public TMP_Text ArmorText; // Referenz zum UI-Text für die Rüstung
    public TMP_Text AmmoText; // Referenz zum UI-Text für die Munition

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the health text with the current health from PlayerStats
        if (playerStats != null && healthText != null)
        {
            healthText.text = "Health: " + playerStats.GetCurrentHealth();
        }

        // Update the armor text with the current armor from PlayerStats
        if (playerStats != null && ArmorText != null)
        {
            ArmorText.text = "Armor: " + playerStats.GetCurrentArmor();
        }

        // Update the ammo text with the current ammo from PlayerShooting
        if (shooting != null && AmmoText != null)
        {
          AmmoText.text = "Ammo: " + playerStats.GetCurrentAmmo();
        }
          else
          {
              Debug.Log("PlayerShooting component not found on PlayerStats GameObject.");
          }
    }


}
