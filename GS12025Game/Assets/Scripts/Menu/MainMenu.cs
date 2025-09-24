using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        gameManager.StartSceneTransitionSequence();
        gameManager.EndSceneTransitionSequence();
        LoadLevel1();
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Quit Game");
        Application.Quit();
    }

    void LoadLevel1()
    {
        // Load Level 1 scene
        SceneManager.LoadScene("Level1");
    }

}
