using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{

    public int scoreValue = 100; //Points for killing this enemy

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.score += scoreValue;
    }
}
