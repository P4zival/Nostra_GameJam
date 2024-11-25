using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject player;                   // Reference to the player (set in the inspector)
    public float moveSpeed = 20f;              // Movement speed of the enemy
    public float rotationSpeed = 3f;           // Rotation speed for the AI to follow the player
    public float attackRange = 85f;            // The range at which the enemy can shoot
    public float fireRate = 1.5f;                // Time between shots
    public GameObject bulletPrefab;            // Bullet prefab to be instantiated
    public float avoidanceRadius = 2f;          // Radius at which to check for nearby enemies
    public LayerMask enemyLayer;                // Layer mask to detect only other enemies



    private float lastFireTime;                // Keeps track of the last time the enemy fired

    private void Start()
    {
        lastFireTime = -fireRate;  // Ensures the enemy can shoot immediately if needed
    }

    private void Update()
    {
        if (player == null) return;

        
        FollowPlayer();
        AvoidOtherEnemies();
        if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            TryShoot();
        }
    }

    private void FollowPlayer()
    {
        // Rotate towards the player
        Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        // Move forward in the direction of the player
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void TryShoot()
    {
        // Only shoot if enough time has passed
        if (Time.time - lastFireTime >= fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
            lastFireTime = Time.time;
        }
    }
    private void AvoidOtherEnemies()
    {
        // Check for other enemies in the specified radius
        Collider[] nearbyEnemies = Physics.OverlapSphere(transform.position, avoidanceRadius, enemyLayer);
        foreach (var enemy in nearbyEnemies)
        {
            if (enemy != null && enemy.gameObject != this.gameObject)
            {
                // Calculate direction to move away from the other enemy
                Vector3 directionAwayFromEnemy = transform.position - enemy.transform.position;
                // Move away from the enemy (optional: adjust the strength of the avoidance force)
                transform.position += directionAwayFromEnemy.normalized * moveSpeed * Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, avoidanceRadius);
    }


}
