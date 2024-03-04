using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of player movement
    public float movementCooldown = 0.2f; // Cooldown between movements
    public Vector2 startingPosition = new Vector2(0, 0); // Starting position of the player
    private float cooldownTimer = 0f; // Timer for movement cooldown
    private Vector2 currentPosition; // Current position of the player
    private Vector2Int gridPosition; // Current position of the player in grid coordinates
    public Vector3Int currentTilePosition; // Current tile position of the player
    public Tilemap tilemap; // Reference to the Tilemap component
    public Tilemap tilemapTwo; // Reference to the second Tilemap component
    public int points = 0; // Points variable

    private void Start()
    {
        currentPosition = startingPosition;
        transform.position = new Vector3(currentPosition.x * 2, currentPosition.y * 2, 0) * moveSpeed;
        gridPosition = Vector2Int.RoundToInt(currentPosition);
        currentTilePosition = tilemap.WorldToCell(transform.position);
    }

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
            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            // Check the tile the player is currently on
            TileBase currentTile = tilemap.GetTile(currentTilePosition);
            if (currentTile != null)
            {
                // Apply movement restrictions based on the current tile
                if (currentTile.name == "tile_4" && horizontalInput > 0)
                    MovePlayer(movement);
                else if ((currentTile.name == "tile_5" || currentTile.name == "tile_13") && (horizontalInput != 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_6" && (horizontalInput < 0 || verticalInput > 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_7" && (horizontalInput > 0 || verticalInput != 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_8" && (horizontalInput < 0 || verticalInput < 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_9" && (horizontalInput > 0 || verticalInput > 0))
                    MovePlayer(movement);
                else if ((currentTile.name == "tile_10" || currentTile.name == "tile_14") && (verticalInput != 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_11" && (horizontalInput > 0 || verticalInput < 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_12" && (horizontalInput != 0 || verticalInput > 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_15" && (verticalInput < 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_16")
                    MovePlayer(movement);
                else if (currentTile.name == "tile_17" && (verticalInput != 0 || horizontalInput < 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_18" && (horizontalInput < 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_19" && (verticalInput > 0))
                    MovePlayer(movement);
                else if (currentTile.name == "tile_20" && (horizontalInput < 0 || verticalInput < 0 || horizontalInput > 0))
                    MovePlayer(movement);
            }

            // Reset cooldown timer
            cooldownTimer = movementCooldown;
        }
    }

    private void MovePlayer(Vector2 movement)
    {
        // Update current position
        currentPosition += movement;

        // Move player object (scaled by moveSpeed)
        transform.position = new Vector3(currentPosition.x * 2, currentPosition.y * 2, 0) * moveSpeed;

        // Update grid position
        gridPosition = Vector2Int.RoundToInt(currentPosition);

        // Update current tile position
        currentTilePosition = tilemap.WorldToCell(transform.position);

        // Check if player moved onto a tile on the points Tilemap
        TileBase currentTileTwo = tilemapTwo.GetTile(currentTilePosition);
        if (currentTileTwo != null)
        {
            if (currentTileTwo.name == "tile_2")
            {
                points += 5;
                // Remove the tile from tilemapTwo
                tilemapTwo.SetTile(currentTilePosition, null);
            }
            else if (currentTileTwo.name == "tile_3")
            {
                points += 10;
                // Remove the tile from tilemapTwo
                tilemapTwo.SetTile(currentTilePosition, null);
            }
        }
    }
}


