using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speedToMove = 3.0f;
    public GameObject playerTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null) // Check if playerTarget is assigned
        {
            // Rotate the enemy to face the player
            transform.LookAt(playerTarget.transform);

            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speedToMove * Time.deltaTime);
        }
        else
        {
            Debug.Log("Kein PlayerTarget gefunden");
        }
    }
}
