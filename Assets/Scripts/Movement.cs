using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    // variables
    public float moveSpeed = 2f;
    public float movementCooldown = 0.2f;
    public Vector2 startingPosition = new Vector2(0, 0);
    private float cooldownTimer = 0f;
    private Vector2 currentPosition;
    private Vector2Int gridPosition;
    public Vector3Int currentTilePosition;
    public Tilemap tilemap;
    public Tilemap tilemapTwo;
    public string nextlevel;

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

        if (cooldownTimer <= 0f)
        {
            // Handle player input
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            // Check the tile the player is currently on
            TileBase currentTile = tilemap.GetTile(currentTilePosition);
            if (currentTile != null)
            {
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

        transform.position = new Vector3(currentPosition.x * 2, currentPosition.y * 2, 0) * moveSpeed;

        gridPosition = Vector2Int.RoundToInt(currentPosition);

        currentTilePosition = tilemap.WorldToCell(transform.position);

        // Check if player moved onto a tile on the points Tilemap
        TileBase currentTileTwo = tilemapTwo.GetTile(currentTilePosition);
        if (currentTileTwo != null)
        {
            if (currentTileTwo.name == "tile_2")
            {
                MainMenu.points += 5;
                tilemapTwo.SetTile(currentTilePosition, null);
            }
            else if (currentTileTwo.name == "tile_3")
            {
                MainMenu.points += 10;
                tilemapTwo.SetTile(currentTilePosition, null);
            }
            else if (currentTileTwo.name == "tile_0")
            {
                SceneManager.LoadScene(nextlevel);
            }
        }
    }
}