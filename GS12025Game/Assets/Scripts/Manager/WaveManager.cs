using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance { get; private set; }
    private List<WaveSpawnerSimple> waves = new List<WaveSpawnerSimple>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of WaveManager detected. Destroying duplicate");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWavespawner(WaveSpawnerSimple enemy)
    {
        waves.Add(enemy);
    }

    public void RemoveWavespawner(WaveSpawnerSimple enemy)
    {
        waves.Remove(enemy);
    }

    public List<WaveSpawnerSimple> GetWaveSpawners()
    {
        return waves;
    }

    public void SetWavespawners(List<WaveSpawnerSimple> Inenemies)
    {
        this.waves = Inenemies;
    }

}
