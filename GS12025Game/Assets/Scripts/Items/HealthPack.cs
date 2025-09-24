using UnityEngine;

public class HealthPack : MonoBehaviour
{

    public GameObject player;
    public int healthAmount = 20; // Amount of health the pack restores

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null && !playerStats.isDead)
            {
                // Heal the player
                playerStats.Heal(healthAmount);
                Debug.Log("Player healed by " + healthAmount + ". Current health: " + playerStats.GetCurrentHealth());
                // Destroy the health pack after use
                Destroy(gameObject);
            }
        }
    }
}
