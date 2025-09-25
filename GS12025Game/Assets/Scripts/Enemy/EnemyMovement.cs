using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speedToMove = 3.0f;
    public GameObject playerTarget;

    private Rigidbody rb; // Reference to the Rigidbody component
    private Vector3 offset; // Random offset for more natural movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Generate a random offset to avoid direct line movement to the player X, Y, Z
        offset = new Vector3(Random.Range(-1.5f, 1.5f), 0, Random.Range(-1.5f, 1.5f)); // Random offset in XZ plane

        rb = GetComponent<Rigidbody>();

        // Prevent drifting of enemies
        rb.linearDamping = 2.0f; // Adjust drag to control sliding
        rb.angularDamping = 2.0f; // Adjust angular drag to control rotation sliding
    }

    void FixedUpdate()
    {
        if (playerTarget != null)
        {
            Vector3 targetPosition = playerTarget.transform.position + offset;
            Vector3 direction = (targetPosition - transform.position).normalized;
            

            // Rotation (optional)
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(targetRotation);

            // Kraft anwenden
            rb.AddForce(direction * speedToMove, ForceMode.Acceleration);

            // Geschwindigkeit begrenzen
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, speedToMove);
        }
        else
        {
            Debug.Log("Kein PlayerTarget gefunden");
        }
    }
}
