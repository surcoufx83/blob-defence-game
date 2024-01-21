using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class SpawnController : MonoBehaviour
{

    public GameControllerScript gameController;
    public TileGridGenerator tileGridGenerator;
    public NavMeshSurface surface;

    public GameObject basicBlob;
    public GameObject stoneThrowerBlob;
    public GameObject wizardBlob;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBlobs());
    }

    IEnumerator SpawnBlobs()
    {
        while (true) // You can replace this with a specific condition if needed
        {
            Debug.Log($"SpawnBlobs() {Time.timeScale}");
            Debug.Log($"SpawnBlobs() {gameController.timer}");
            if (Time.timeScale > 0 && gameController.timer >= 0f && tileGridGenerator.tiles != null) // Check if the game is running
            {
                SpawnBlobAtEdge();
            }
            yield return new WaitForSeconds(Time.timeScale > 0 ? 5 : 1); // Wait for 5 seconds before next spawn if game is running
        }
    }

    void SpawnBlobAtEdge()
    {
        var (blobPrefab, count) = SelectBlobToSpawn();
        Vector3 baseSpawnPosition;
        bool suitablePositionFound = false;

        while (!suitablePositionFound)
        {
            baseSpawnPosition = GetRandomEdgePosition();
            if (IsPositionSuitable(baseSpawnPosition))
            {
                suitablePositionFound = true;
                for (int i = 0; i < count; i++)
                {
                    Vector3 spawnPosition = baseSpawnPosition + new Vector3(Random.Range(-i * 0.2f, i * 0.2f), 0.2f, Random.Range(-i * 0.2f, i * 0.2f)); // Adjust to prevent overlapping
                    GameObject blob = Instantiate(blobPrefab, spawnPosition, Quaternion.identity, surface.transform);
                    NavMeshAgent agent = blob.GetComponent<NavMeshAgent>();
                    if (agent != null && gameController.PlayerChest != null)
                    {
                        agent.destination = gameController.PlayerChest.transform.position;
                    }
                }
            }
        }
    }

    (GameObject, int) SelectBlobToSpawn()
    {
        if (gameController.timer < 30)
        {
            return (basicBlob, 1);
        }
        else if (gameController.timer < 60)
        {
            return (Random.Range(0, 2) == 0 ? basicBlob : stoneThrowerBlob, 1);
        }
        else if (gameController.timer < 90)
        {
            int type = Random.Range(0, 3);
            return (type == 0 ? basicBlob : type == 1 ? stoneThrowerBlob : wizardBlob, type == 0 ? 2 : 1);
        }
        else
        {
            int type = Random.Range(0, 3);
            return (type == 0 ? basicBlob : type == 1 ? stoneThrowerBlob : wizardBlob, type == 0 ? 3 : type == 1 ? 2 : 1);
        }
    }

    Vector3 GetRandomEdgePosition()
    {
        float gridSizeX = tileGridGenerator.gridWidth * tileGridGenerator.tileSpacing;
        float gridSizeZ = tileGridGenerator.gridHeight * tileGridGenerator.tileSpacing;
        float halfSizeX = gridSizeX / 2.0f;
        float halfSizeZ = gridSizeZ / 2.0f;

        // Offset to spawn one tile inward
        float offset = tileGridGenerator.tileSpacing;

        int edge = Random.Range(0, 4);
        float x = 0, z = 0;

        switch (edge)
        {
            case 0: // Top edge
                x = Random.Range(-halfSizeX + offset, halfSizeX - offset);
                z = halfSizeZ - offset;
                break;
            case 1: // Bottom edge
                x = Random.Range(-halfSizeX + offset, halfSizeX - offset);
                z = -halfSizeZ + offset;
                break;
            case 2: // Left edge
                x = -halfSizeX + offset;
                z = Random.Range(-halfSizeZ + offset, halfSizeZ - offset);
                break;
            case 3: // Right edge
                x = halfSizeX - offset;
                z = Random.Range(-halfSizeZ + offset, halfSizeZ - offset);
                break;
        }

        return new Vector3(x, 0, z); // Assuming y = 0 for ground level
    }

    bool IsPositionSuitable(Vector3 position)
    {
        // Convert world position to grid coordinates
        int x = Mathf.RoundToInt((position.x + tileGridGenerator.gridWidth * tileGridGenerator.tileSpacing / 2) / tileGridGenerator.tileSpacing);
        int y = Mathf.RoundToInt((position.z + tileGridGenerator.gridHeight * tileGridGenerator.tileSpacing / 2) / tileGridGenerator.tileSpacing);

        // Check grid bounds
        if (x < 0 || x >= tileGridGenerator.gridWidth || y < 0 || y >= tileGridGenerator.gridHeight)
        {
            return false;
        }
        // Get the tile at these coordinates
        GameObject tile = tileGridGenerator.tiles[x, y];

        // Check if the tile has a GroundTileProperties component and if blob spawning is enabled
        GroundTileProperties properties = tile.GetComponent<GroundTileProperties>();
        if (properties != null && properties.enableBlobSpawn)
        {
            return true; // Suitable for spawning
        }

        return false; // Not suitable
    }
}
