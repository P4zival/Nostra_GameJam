using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLvl1 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 10f;        // Normal horizontal speed
    public float jumpForce = 15f;        // Force applied when jumping
    public LayerMask groundLayer;        // Layer to check if the player is grounded
    public Transform groundCheck;        // Position to check if grounded
    public float groundCheckRadius = 0.2f;

    [Header("Dash Settings")]
    public float dashSpeed = 25f;        // Speed during dash
    public float dashDuration = 0.2f;    // How long the dash lasts
    public float dashCooldown = 1.0f;    // Cooldown time before dashing again

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDashing = false;
    private float dashTime;
    private float lastDashTime;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleJump();

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            StartCoroutine(Dash());
        }
    }

    private void HandleMovement()
    {
        // Skip movement input while dashing
        if (isDashing) return;

        // Get horizontal input (A/D keys or Left/Right arrows)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        // Check if the player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Jump when the spacebar is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        dashTime = Time.time;
        lastDashTime = Time.time;

        // Store the current horizontal input direction
        float dashDirection = Input.GetAxisRaw("Horizontal");
        if (dashDirection == 0) dashDirection = 1; // Default to dashing to the right if no input

        // Apply dash velocity
        rb.velocity = new Vector2(dashDirection * dashSpeed, rb.velocity.y);

        // Wait for the dash duration
        yield return new WaitForSeconds(dashDuration);

        // Reset to normal speed after dashing
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player hits an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            // Implement game over logic here (e.g., restart level or stop movement)
        }
    }
}