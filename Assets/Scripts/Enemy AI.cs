using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;                   // Reference to the player (set in the inspector)
    public float moveSpeed = 10f;              // Movement speed of the enemy
    public float rotationSpeed = 2f;           // Rotation speed for the AI to follow the player
    public float attackRange = 50f;            // The range at which the enemy can shoot
    public float fireRate = 1f;                // Time between shots
    public GameObject bulletPrefab;            // Bullet prefab to be instantiated
    public Transform gunBarrel;                // The point from where bullets will be shot

    private float lastFireTime;                // Keeps track of the last time the enemy fired

    private void Start()
    {
        lastFireTime = -fireRate;  // Ensures the enemy can shoot immediately if needed
    }

    private void Update()
    {
        if (player == null) return;

        // Rotate and move towards the player
        FollowPlayer();

        // Shoot at the player if within attack range
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            TryShoot();
        }
    }

    private void FollowPlayer()
    {
        // Rotate towards the player
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
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
            Shoot();
            lastFireTime = Time.time;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab && gunBarrel)
        {
            // Instantiate bullet and set direction
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.velocity = gunBarrel.forward * 20f; // Set bullet velocity (adjust as needed)
            }
            Destroy(bullet, 5f);  // Destroy the bullet after 5 seconds to avoid unnecessary clutter
        }
    }

    private void OnDestroy()
    {
        // Notify the GameManager that an enemy was destroyed (if there's a GameManager)
        EnemyManager.Instance.EnemyDestroyed();
    }
}
