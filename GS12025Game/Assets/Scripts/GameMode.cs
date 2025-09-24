using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sauberer mit Delta Time zu arbeiten
        //Wenn die Enemy Liste leer ist, hat man gewonnen (Bei Endlos spawnen wie bei uns muss man anpassen)
       /* if(EnemyManager.instance.GetEnemies().Count == 0 && WaveManager.instance.GetWaveSpawners().Count == 0)
        {
            SceneManager.LoadScene("WinScene");
            Debug.Log("You win");
        }
       */
       if(ScoreManager.instance.score >= 1000)
        {
            SceneManager.LoadScene("WinScene");
            Debug.Log("You win");
        }
    }
}
