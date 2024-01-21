using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlobMovementAI : MonoBehaviour
{

    public GameControllerScript gameController;
    public TileGridGenerator tileGridGenerator;

    private GameObject target;
    //private NavMeshAgent agent;

    void Start()
    {

        //Debug.Log($"Starting blob entity ${gameObject.name}");
        //Debug.Log($" gameController is null = ${gameController == null}");
        //Debug.Log($" tileGridGenerator is null = ${tileGridGenerator == null}");
        //Debug.Log($" gameController.PlayerChest is null = ${gameController.PlayerChest == null}");

        if (gameController == null && gameController.PlayerChest == null && tileGridGenerator == null)
            return;

        target = gameController.PlayerChest;

        Debug.Log($"target ${target.name}");

        //agent = GetComponent<NavMeshAgent>();
        //agent.speed = CalculateMovementSpeed();
        //agent.SetDestination(target.transform.position);
    }

    void Update()
    {
        // You can add additional behavior here if needed
    }

    //float CalculateMovementSpeed()
    //{
    //    // Get the tile position where the blob is located
    //    Vector3 tilePosition = transform.position;

    //    // Convert world position to grid coordinates
    //    int x = Mathf.RoundToInt((tilePosition.x + tileGridGenerator.gridWidth * tileGridGenerator.tileSpacing / 2) / tileGridGenerator.tileSpacing);
    //    int y = Mathf.RoundToInt((tilePosition.z + tileGridGenerator.gridHeight * tileGridGenerator.tileSpacing / 2) / tileGridGenerator.tileSpacing);

    //    // Check grid bounds
    //    if (x < 0 || x >= tileGridGenerator.gridWidth || y < 0 || y >= tileGridGenerator.gridHeight)
    //    {
    //        return 0; // Return 0 speed for invalid positions
    //    }

    //    // Get the tile at these coordinates
    //    GameObject tile = tileGridGenerator.tiles[x, y];

    //    // Check if the tile has a GroundTileProperties component
    //    GroundTileProperties properties = tile.GetComponent<GroundTileProperties>();
    //    if (properties != null)
    //    {
    //        // Adjust speed based on tile's movementSpeedFactor
    //        return agent.speed * properties.movementSpeedFactor;
    //    }

    //    return agent.speed;
    //}
}
