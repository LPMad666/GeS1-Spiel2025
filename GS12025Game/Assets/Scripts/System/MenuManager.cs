using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject pauseMenu; // Referenz zum Pause Menu

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        KeyEvents();
    }

    void KeyEvents()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPauseMenu();
        }
    }

    void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //Pause Menu öffnen
        Debug.Log("Pause Menu opened");
        Time.timeScale = 0f; //Spiel pausieren
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; //Spiel fortsetzen
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
