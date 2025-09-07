using UnityEngine;

public class WaveSpawnerSimple : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public float startTime;
    public float endTime;
    public float spawnRate;

    public float timeBetweenWaves = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start spawning enemies after startTime and repeat every spawnRate seconds
        InvokeRepeating("Spawn", startTime, spawnRate);
        // Cancel spawning after endTime seconds
        Invoke("CancelSpawn", endTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        // Spawn an enemy at the spawn point 
        Debug.Log("Spawned Enemy started");
        Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
    }

    void CancelSpawn()
    {
        // Cancel the repeated spawning of enemies after endTime
        CancelInvoke("Spawn");
        Debug.Log("Spawned Enemy cancelled");
       
        // Invoke again after timeBetweenWaves to restart spawning
        Invoke("RestartSpawning", timeBetweenWaves);
    }
}
