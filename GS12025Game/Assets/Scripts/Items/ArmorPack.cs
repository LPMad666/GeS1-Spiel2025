using UnityEngine;

public class ArmorPack : MonoBehaviour
{

    private GameObject playerTarget; // Reference to the player's transform
    public int armorAmount; //Amount of Armor the Pack replenishes 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemManager parentRef = GetComponentInParent<ItemManager>(); // Get reference to ItemManager in parent

        if (parentRef != null)
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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = playerTarget.GetComponent<PlayerStats>();
        if (playerTarget != null)
        {
            playerStats.ArmorReplenish(armorAmount);
            Debug.Log("Player Armor replenish " + armorAmount + ". Current Armor: " + playerStats.GetCurrentArmor());
            //Destroy after use of Armor pack
            Destroy(gameObject);
        }
    }

}
