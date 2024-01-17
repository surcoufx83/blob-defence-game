using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject PlayerChest;

    public Text gameStateMessagesText;

    [Range(0f, 9999f)]
    public float TimeBeforeGameStarts = 10.0f;

    private float timer;
    private bool countdown = true;

    public TileGridGenerator tileGridGenerator;

    public GameObject basicBlob;
    public GameObject stoneThrowerBlob;
    public GameObject wizardBlob;

    [Range(1, 20)]
    public int spawnInterval = 5;

    void Start()
    {
        timer = TimeBeforeGameStarts;
        Time.timeScale = 0; // Pause the game simulation
        StartCoroutine(SpawnBlobs());
    }

    void Update()
    {
        if (countdown)
        {
            timer -= Time.unscaledDeltaTime; // Use unscaledDeltaTime to count down while the game is paused
            if (timer <= 0)
            {
                timer = 0;
                countdown = false;
                Time.timeScale = 1; // Resume the game simulation
            }
        }
        else
        {
            timer += Time.unscaledDeltaTime; // Count up after the countdown
        }

        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer % 60;
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        gameStateMessagesText.text = countdown ? "Starting in: " + formattedTime : formattedTime;
    }

    IEnumerator SpawnBlobs()
    {
        while (true) // You can replace this with a specific condition if needed
        {
            if (Time.timeScale > 0) // Check if the game is running
            {
                SpawnBlobAtEdge();
            }
            yield return new WaitForSeconds(5); // Wait for 5 seconds before next spawn
        }
    }

    void SpawnBlobAtEdge()
    {
        GameObject blobToSpawn = SelectBlobToSpawn();

        Vector3 spawnPosition = GetRandomEdgePosition();
        if (IsPositionSuitable(spawnPosition))
        {
            Instantiate(blobToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    GameObject SelectBlobToSpawn()
    {
        // Modify this logic as per your game's design
        if (timer < 30)
        {
            return basicBlob;
        }
        else if (timer < 60)
        {
            return Random.Range(0, 2) == 0 ? basicBlob : stoneThrowerBlob;
        }
        else if (timer < 90)
        {
            return Random.Range(0, 3) switch
            {
                0 => basicBlob,
                1 => basicBlob,
                2 => Random.Range(0, 2) == 0 ? stoneThrowerBlob : wizardBlob,
                _ => basicBlob,
            };
        }
        else
        {
            return Random.Range(0, 6) switch
            {
                0 => basicBlob,
                1 => basicBlob,
                2 => basicBlob,
                3 => stoneThrowerBlob,
                4 => stoneThrowerBlob,
                5 => wizardBlob,
                _ => basicBlob,
            };
        }
    }

    Vector3 GetRandomEdgePosition()
    {
        // Implement logic to get a random position along the edge of the grid
        // Ensure the selected position is not in deep water
    }

    bool IsPositionSuitable(Vector3 position)
    {
        // Implement logic to check if the position is not on deep water
    }

}
