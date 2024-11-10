using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AircraftController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 20f;
    public float maxSpeed = 50f;
    public float turnSpeed = 45f;
    public float smoothTurnTime = 0.2f;
    private float currentSpeed = 0f;
    private float smoothTurnVelocity;
    public int CurrentLives = 3;
    public Transform LvlSpawnPos;
    private Rigidbody rb;
    private EnemyAI eai;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        eai = GetComponent<EnemyAI>();
        rb.freezeRotation = true; 
    }
    void Update()
    {
        HandleMovement();
        LivesDetect();
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
        horizontalInput = -horizontalInput;
        float smoothTurn = Mathf.SmoothDampAngle(transform.eulerAngles.z, transform.eulerAngles.z + (horizontalInput * turnSpeed), ref smoothTurnVelocity, smoothTurnTime);
        // Apply movement and rotation
        rb.velocity = transform.up * currentSpeed;
        transform.rotation = Quaternion.Euler(0, 0, smoothTurn);
    }
    void LivesDetect()
    {
        if (CurrentLives == 0)
        {
            Debug.Log("Game Over");
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

    public void LevelReset()
    {
        this.gameObject.transform.position = LvlSpawnPos.transform.position;
        this.gameObject.SetActive(true);
        CurrentLives--;
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player hits an obstacle
        if (collision.collider.CompareTag("Enemy Bullet"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Game Over!");
            LevelReset();
        }
        
    }
}