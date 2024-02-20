using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of player movement
    public int gridSize = 8; // Size of the grid
    public float movementCooldown = 0.2f; // Cooldown between movements
    private float cooldownTimer = 0f; // Timer for movement cooldown
    private Vector2Int currentPosition; // Current position of the player in grid coordinates

    private void Update()
    {
        // Update cooldown timer
        cooldownTimer -= Time.deltaTime;

        // Handle player input if cooldown is over
        if (cooldownTimer <= 0f)
        {
            // Handle player input
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            // Calculate movement direction
            Vector2Int movement = new Vector2Int(Mathf.RoundToInt(horizontalInput), Mathf.RoundToInt(verticalInput));

            // Check if movement is valid
            if (IsValidMove(movement))
            {
                // Update current position
                currentPosition += movement;

                // Move player object (scaled by moveSpeed)
                transform.position = new Vector3(currentPosition.x * 2, currentPosition.y * 2, 0) * moveSpeed;

                // Reset cooldown timer
                cooldownTimer = movementCooldown;
            }
        }
    }

    // Check if the movement is within the grid bounds
    private bool IsValidMove(Vector2Int movement)
    {
        Vector2Int newPosition = currentPosition + movement;
        return newPosition.x >= 0 && newPosition.x < gridSize && newPosition.y >= 0 && newPosition.y < gridSize;
    }
}

