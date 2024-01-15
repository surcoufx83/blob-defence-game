using UnityEngine;

public class TileGridGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs; // Array to hold different tile prefabs
    [Range(10, 1000)]
    public int gridWidth = 1;
    [Range(10, 1000)]
    public int gridHeight = 1;
    private float tileSpacing = 1f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Calculate the offset to center the grid
        float widthOffset = gridWidth / 2.0f * tileSpacing;
        float heightOffset = gridHeight / 2.0f * tileSpacing;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
               int tileIndex = Random.Range(0, tilePrefabs.Length);
                Vector3 spawnPosition = new Vector3(x * tileSpacing - widthOffset, 0, y * tileSpacing - heightOffset);
                GameObject tilePrefab = tilePrefabs[tileIndex];
                Instantiate(tilePrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
    }
}
