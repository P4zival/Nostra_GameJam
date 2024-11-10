using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public float damage = 10f;  // The damage dealt by the bullet

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet hits the player or other targets
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player or other behavior
            Debug.Log("Player hit!");
            PlayerPrefab.SetActive(false);
            Destroy(gameObject);  // Destroy bullet on impact
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Optional: If bullet hits another enemy, deal damage
            Destroy(gameObject);  // Destroy bullet on impact
        }
        else
        {
            Destroy(gameObject);  // Destroy bullet if it hits anything else
        }
    }
}
