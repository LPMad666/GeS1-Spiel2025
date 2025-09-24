using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    private float speedTranslation;

    [SerializeField]
    private float speedRotation;

    [SerializeField]
    private float jumpVelocity;

    private Rigidbody rb;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Holt die Rigidbody-Komponente des GameObjects 
    }

    // Update is called once per frame
    void Update()
    {
        this.Movement();

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.R))
        {
            GetComponent<PlayerShooting>().Reload(30);
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))  //Sprinten
                transform.Translate(0, 0, speedTranslation * 2 * Time.deltaTime);
            else
            transform.Translate(0, 0, speedTranslation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speedTranslation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedTranslation * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedTranslation * Time.deltaTime, 0, 0);
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse); // Sprungkraft anwenden
        isGrounded = false; // Spieler ist in der Luft
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Spieler ist wieder auf dem Boden
        }
    }
}
