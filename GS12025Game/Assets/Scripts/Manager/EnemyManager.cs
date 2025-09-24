using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static EnemyManager instance { get; private set; }
    private List<EnemyConnector> enemies = new List<EnemyConnector>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of EnemyManager detected. Destroying duplicate");
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

    public void AddEnemy(EnemyConnector enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyConnector enemy)
    {
        enemies.Remove(enemy);
    }

    public List <EnemyConnector> GetEnemies()
    {
        return enemies;
    }

    public void SetEnemies(List<EnemyConnector> Inenemies)
    {
        this.enemies = Inenemies;
    }
}
