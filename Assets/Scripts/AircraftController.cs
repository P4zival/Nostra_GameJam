using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour
{

    [Header("Movement Settings")]
    public float forwardSpeed = 20f;
    public float maxSpeed = 50f;
    public float turnSpeed = 45f;
    public float smoothTurnTime = 0.2f;

    private float currentSpeed = 0f;
    private float smoothTurnVelocity;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevents the Rigidbody from handling rotation
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Forward movement using the "W" key
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime);
        }
      
       
        // Horizontal turning using "A" and "D" keys
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.z, transform.eulerAngles.z + (horizontalInput * turnSpeed), ref smoothTurnVelocity, smoothTurnTime);
        Debug.Log($"FORWARD PRESSED : {transform.forward * currentSpeed}");
        // Apply movement and rotation
        rb.velocity = transform.up * currentSpeed;
        transform.rotation = Quaternion.Euler(0,0, smoothTurn);
        
    }

}
