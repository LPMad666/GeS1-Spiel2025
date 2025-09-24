using UnityEngine;

public class WaveSpawnerSimple : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPoint;
    public GameObject playerTarget;
    public float startTime;
    public float endTime;
    public float spawnRate;

    public float timeBetweenWaves = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        WaveManager.instance.AddWavespawner(this);
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
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity); // Create an instance of the enemy prefab at the spawn point
        enemyInstance.GetComponent<EnemyMovement>().playerTarget = playerTarget; // Assign the player target to the enemy
        enemyInstance.GetComponent<EnemyAttack>().playerTarget = playerTarget; //Assign the player target to the enemy for attacks
    }

    void CancelSpawn()
    {
        // Cancel the repeated spawning of enemies after endTime
        CancelInvoke("Spawn");
        Debug.Log("Spawned Enemy cancelled");

        //To delete from waveManager 
        // WaveManager.instance.RemoveWavespawner(this);
       
        // Invoke again after timeBetweenWaves to restart spawning
        Invoke("RestartSpawning", timeBetweenWaves);
    }

    void RestartSpawning()
    {
        // Start spawning enemies after startTime and repeat every spawnRate seconds
        InvokeRepeating("Spawn", startTime, spawnRate);
        // Cancel spawning after endTime seconds
        Invoke("CancelSpawn", endTime);
    }
}
