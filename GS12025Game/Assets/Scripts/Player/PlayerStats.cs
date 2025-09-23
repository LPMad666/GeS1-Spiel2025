using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI Elements")]
    public GameObject deathScreen; // UI Element für den Todesscreen
    public UIHitEffect hitEffect; //direkt Feld Überweisung statt FindObject

    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start

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
        currentHealth -= damage; // Reduce current health by the damage amount
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Clamp health between 0 and maxHealth to avoid negative values
        Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);

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

    public int GetCurrentHealth()
    {
        return currentHealth; // Return the current health value
    }

    public int GetCurrentArmor()
    {
        // Placeholder for armor logic, currently returns 0
        return 0;
    }

}
