using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth = 100;
    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health at the start
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
        if (currentHealth <= 0)
        {
            Die(); // Call Die method if health drops to zero or below
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Return the current health value
    }

}
