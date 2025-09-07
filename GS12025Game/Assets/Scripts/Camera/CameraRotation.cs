using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField]
    public float rotationSpeed = 5.0f; // Geschwindigkeit der Kamerarotation

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
        float mouseY = Input.GetAxis("Mouse Y"); 
        transform.Rotate(mouseY * (rotationSpeed * Time.deltaTime), 0, 0);
    }
} 
