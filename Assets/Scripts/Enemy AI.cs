/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;               // Reference to the player's transform
    public GameObject EnemyBulletPrefab;        // Bullet prefab to be shot
    public float MoveSpeed = 5f;           // Speed at which the enemy moves
    public float ShootInterval = 2f;       // Time interval between shots
    public float AttackRange = 10f;        // Distance at which the enemy starts shooting
    public float RotationSpeed = 2f;       // Speed of rotation towards the player

    private float timeSinceLastShot = 0f;

    // Event for when an enemy is destroyed
    public event Action<GameObject> onEnemyDestroyed;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player is not assigned!");
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
        ShootAtPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Calculate direction to the player
        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.z = 0f;  // Ensure we are only considering the X and Y axes

        if (directionToPlayer.magnitude > attackRange)
        {
            // Move towards the player
            directionToPlayer.Normalize();
            transform.position += directionToPlayer * moveSpeed * Time.deltaTime;
        }
        else
        {
            // Stay in position if within attack range
            // Optionally, you can add attack behaviors here like hovering or circling
        }

        // Rotate towards the player
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void ShootAtPlayer()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval)
        {
            // Shoot a bullet if within attack range
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                ShootBullet();
                timeSinceLastShot = 0f;
            }
        }
    }

    void ShootBullet()
    {
        // Instantiate the bullet and shoot it towards the player
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f; // Bullet speed
    }

    // Call this when the enemy is destroyed
    public void DestroyEnemy()
    {
        // Trigger the event when the enemy is destroyed
        onEnemyDestroyed?.Invoke(gameObject);
        Destroy(gameObject);
    }

}
*/