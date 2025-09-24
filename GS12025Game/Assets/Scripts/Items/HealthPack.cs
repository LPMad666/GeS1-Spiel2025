using UnityEngine;

public class HealthPack : MonoBehaviour
{

    private GameObject playerTarget; // Reference to the player's transform
    public int healthAmount = 20; // Amount of health the pack restores

    [SerializeField]
    float rotationSpeedX, rotationSpeedY, rotationSpeedZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemManager parentRef = GetComponentInParent<ItemManager>(); // Get reference to ItemManager in parent

        if(parentRef != null)
        {
            playerTarget = parentRef.player; // Assign the player's transform from ItemManager
        }
        else
        {
            Debug.LogError("ItemManager not found in parent hierarchy.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ); // Rotate the health pack for visual effect
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerTarget)
        {
            PlayerStats playerStats = playerTarget.GetComponent<PlayerStats>();
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
