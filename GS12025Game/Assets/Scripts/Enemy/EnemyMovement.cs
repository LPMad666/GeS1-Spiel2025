using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speedToMove = 3.0f;
    public GameObject playerTarget;
    public Animator Animation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null) // Check if playerTarget is assigned
        {
            // Move the enemy towards the player
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.transform.position, speedToMove * Time.deltaTime);
            Animation.SetBool("IsWalking", true); // Set the walking animation)
        }
        else
        {
            Debug.Log("Kein PlayerTarget gefunden");
            Animation.SetBool("IsWalking", false); // Stop the walking animation
        }
    }
}
