using UnityEngine;

public class EnemyConnector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyManager.instance.AddEnemy(this);  //Trag dich selbst in die Liste von Enemies ein. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EnemyManager.instance.RemoveEnemy(this);
    }
}
