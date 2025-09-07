using UnityEngine;

public class MouseLock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Cursor unsichtbar setzen 
        //Cursor.visible = false;

        //Cursor einfrieren, nicht mehr über mehrere Bildschirme bewegen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
