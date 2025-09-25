using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speedToMove = 3.0f;
    public GameObject playerTarget;

    private Vector3 offset; // Random offset for more natural movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generate a random offset to avoid direct line movement to the player X, Y, Z
        offset = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(-4f, 4f)); // Random offset in XZ plane
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null) // Check if playerTarget is assigned
        {
            // Apply the offset to the player's position
            Vector3 targetPosition = playerTarget.transform.position + offset;

            // Rotate the enemy to face the player
            transform.LookAt(targetPosition);

            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speedToMove * Time.deltaTime);
        }
        else
        {
            Debug.Log("Kein PlayerTarget gefunden");
        }
    }
}
