using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMP_Text ScoreText; // Referenz zum UI-Text für die Rüstung
    public GameObject deathScreen; // UI Element für den Todesscreen

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update the armor text with the current armor from PlayerStats
        if (ScoreText != null)
        {
            ScoreText.text = "Score: " + ScoreManager.instance.score;
        }
    }

    public void RestartLevel()
    {
        //aktuelle Szene neuladen - Gegner reset, Player HP reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
