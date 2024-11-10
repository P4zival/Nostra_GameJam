using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;               // Reference to the enemy prefab
    public Transform spawnPoints;              // Points in the scene where enemies will spawn
    public int maxEnemies = 5;

    private EnemyAI EAI;
    private void Start()
    {
        EAI = GetComponent<EnemyAI>();
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        // Spawn an enemy at a random spawn point
        Transform spawnPoint = spawnPoints;

        for (int i = 0; i < maxEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    
}