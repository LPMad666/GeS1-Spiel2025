using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    public int maxArmor = 50;
    public int maxAmmo = 30;
    private int currentHealth;
    private int currentArmor;
    private int currentAmmo;

    [Header("UI Elements")]
    public GameObject deathScreen; // UI Element für den Todesscreen
    public UIHitEffect hitEffect; //direkt Feld Überweisung statt FindObject

    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
        currentArmor = maxArmor;   // Initialize current armor to max armor at the start
        currentAmmo = maxAmmo; // Initialize current ammo to max ammo at the start

        // DeathScreen am Anfang unsichtbar machen
        if (deathScreen != null)
            deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (currentArmor > 0)
        {
            int armorDamage = Mathf.Min(damage, currentArmor); // Calculate how much damage can be absorbed by armor
            currentArmor -= armorDamage; // Reduce current armor by the absorbed damage
            damage -= armorDamage; // Reduce the remaining damage
            Debug.Log("Player's armor absorbed " + armorDamage + " damage. Current armor: " + currentArmor);
        }
        else
        {
            currentHealth -= damage; // Reduce current health by the damage amount
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth to avoid negative values
            Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);
        }

        //Hit Effect triggern
      //  GetComponent<PlayerHitEffect>().TriggerHitEffect();

        // Bildschirm Overlay triggern 
        if  (hitEffect != null) 
            hitEffect.TriggerHitEffect();

        if (currentHealth <= 0)
        {
            Die(); // Call Die method if health drops to zero or below
        }
    }

    private void Die()
    {
        if (isDead) return; // verhindert Doppelaufruf
        isDead = true;

        Debug.Log("Player has died.");

        // Steuerung vom Spieler ausschalten.
        GetComponent<SimpleMovement>().enabled = false;
        //Schuss vom Spieler ausschalten.
        GetComponent<PlayerShooting>().enabled = false;

        // Hier können weitere Aktionen beim Tod des Spielers hinzugefügt werden, z.B. Animationen, Neustart des Levels, etc.
        // Death Screen anzeigen
        if (deathScreen != null)
            deathScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None; //Cursor wieder sichtbar machen
    }

    public void ReduceAmmo(int reduce)
    {
        currentAmmo = currentAmmo - reduce;
    }

    public bool ReloadAmmo(int ammo)
    {
        if (currentAmmo < maxAmmo)
        {
            currentAmmo += ammo;
            currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo); // Clamp ammo between 0 and maxAmmo to avoid exceeding max
            Debug.Log("Player reloaded " + ammo + " ammo. Current ammo: " + currentAmmo);
            return true; // Reload successful
        }
        else
        {
            Debug.Log("Ammo is already full. Current ammo: " + currentAmmo);
            return false; // Ammo is already full
        }
    }

    public void Heal(int healAmount)
    {
        if (isDead) return; // Dead players can't be healed

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth to avoid exceeding max
        Debug.Log("Player healed by " + healAmount + ". Current health: " + currentHealth);
    }

    public void ArmorReplenish(int armorAmount)
    {
        if (isDead) return; //Dead players don't get armor

        currentArmor += armorAmount;
        currentArmor = Mathf.Clamp(currentArmor, 0, maxArmor); //Clamp Armor between 0 and maxArmor
        Debug.Log("Player gained " +  armorAmount + ". Current Armor: " + currentArmor);
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Return the current health value
    }

    public int GetCurrentArmor()
    {
        // Placeholder for armor logic, currently returns 0
        return currentArmor;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo; // Return the current ammo count
    }

    public Vector3 GetLookDirection()
    {
        return transform.forward; // Return the forward direction of the player
    }

}
