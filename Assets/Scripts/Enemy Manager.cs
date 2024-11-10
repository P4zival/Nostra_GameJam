/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;        // The enemy prefab to instantiate
    public int maxEnemies = 5;            // The maximum number of enemies in the scene
    public Transform[] spawnPoints;       // Array of spawn points where enemies will appear

    private List<GameObject> activeEnemies = new List<GameObject>();  // List to track active enemies

    void Start()
    {
        // Initially spawn the maximum number of enemies
        SpawnEnemies();
    }

    void Update()
    {
        // Ensure that the number of active enemies never exceeds maxEnemies
        CheckAndRespawnEnemies();
    }

    void SpawnEnemies()
    {
        // Spawn the maximum number of enemies at predefined spawn points
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (activeEnemies.Count < maxEnemies)
            {
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                activeEnemies.Add(newEnemy);

                // Optionally, you can attach a listener to the enemy's death event
                newEnemy.GetComponent<EnemyAI>().onEnemyDestroyed += HandleEnemyDestroyed;
            }
        }
    }

    void CheckAndRespawnEnemies()
    {
        // Remove any null references (destroyed enemies) from the list
        activeEnemies.RemoveAll(enemy => enemy == null);

        // If there are fewer enemies than maxEnemies, spawn new ones
        while (activeEnemies.Count < maxEnemies)
        {
            SpawnNextEnemy();
        }
    }

    void SpawnNextEnemy()
    {
        // Choose a random spawn point to instantiate a new enemy
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        activeEnemies.Add(newEnemy);

        // Optionally, you can attach a listener to the enemy's death event
        newEnemy.GetComponent<EnemyAI>().onEnemyDestroyed += HandleEnemyDestroyed;
    }

    void HandleEnemyDestroyed(GameObject enemy)
    {
        // This will be called when an enemy is destroyed
        activeEnemies.Remove(enemy);
        Destroy(enemy);  // Destroy the enemy object
        SpawnNextEnemy(); // Spawn a new enemy to maintain the count
    }
}*/