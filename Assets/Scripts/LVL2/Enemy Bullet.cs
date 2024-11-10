using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 20f; 

    private Rigidbody rb;

    private void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
        Destroy(gameObject, 5f);
    }
}
