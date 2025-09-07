using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField]
    private float speedTranslation;

    [SerializeField]
    private float speedRotation;

    [SerializeField]
    private float jumpVelocity;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.Movement();
        this.Rotation();
    }

    private void Rotation()  //Rotation Kamera um die Y Achse.
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * (speedRotation * Time.deltaTime), 0);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
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
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpVelocity * Time.deltaTime, 0);
        }
    }
}
