using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{

    public int scoreValue = 100; //Points for killing this enemy
    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        isDead = true;
        AddScore();
    }

    public void AddScore()
    {
        if (ScoreManager.instance != null && isDead)
        {
            ScoreManager.instance.score += scoreValue;
            Debug.Log("Score increased by " + scoreValue + ". Total Score: " + ScoreManager.instance.score);
        }
        else
        {
            Debug.LogWarning("ScoreManager instance not found. Cannot add score.");
        }
    }

}
