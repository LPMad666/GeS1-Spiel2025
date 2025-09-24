using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField]
    public float mouseXSensitivity= 5.0f; // Geschwindigkeit der Kamerarotation X
    [SerializeField]
    public float mouseYSensitivity= 5.0f; // Geschwindigkeit der Kamerarotation Y

    private float xRotation = 0f; // Aktuelle Rotation um die X-Achse

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }
    private void Rotation()
    {
        // Mausbewegung erfassen
        float mouseY = Input.GetAxis("Mouse Y") * mouseYSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * mouseXSensitivity;

        // Kamera um die Y-Achse drehen (horizontal)
        //transform.Rotate(mouseY * (rotationSpeed * Time.deltaTime), 0, 0);

        // Drehe das übergeordnete Objekt [Player] um die Y-Achse basierend auf der Mausbewegung
        transform.parent.Rotate(Vector3.up, mouseX); 

        // Kamera um die X-Achse drehen (vertikal)
        xRotation -= mouseY * (mouseYSensitivity * Time.deltaTime); // Invertiere die Y-Achse für natürlichere Steuerung
        xRotation = Mathf.Clamp(xRotation, -20f, 20f); // Begrenze die Rotation um die X-Achse auf (oben) -20 bis (unten) 20 Grad

        transform.localEulerAngles = new Vector3(xRotation, 0f, 0f); // Setze die lokale Rotation der Kamera um die X-Achse, Kamera dreht sich relativ zum Player, nicht absolut.
    }
} 
