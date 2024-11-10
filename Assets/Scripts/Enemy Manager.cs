using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;          // Singleton instance of GameManager

    public GameObject enemyPrefab;               // Reference to the enemy prefab
    public Transform[] spawnPoints;              // Points in the scene where enemies will spawn
    public int maxEnemies = 5;                   // Maximum number of enemies in the scene at any time

    private void Awake()
    {
        // Singleton pattern to ensure there's only one instance of the GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Spawn initial enemies at the start of the game
        SpawnInitialEnemies();
    }

    private void SpawnInitialEnemies()
    {
        // Ensure we spawn the correct number of enemies (maxEnemies)
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    public void EnemyDestroyed()
    {
        // Every time an enemy is destroyed, spawn a new one
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Spawn an enemy at a random spawn point
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}