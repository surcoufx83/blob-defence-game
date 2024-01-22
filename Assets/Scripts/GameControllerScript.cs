using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript: MonoBehaviour
{

    public GameObject PlayerChest;

    public Text gameStateMessagesText;

    public EntityUiController entityUiController;
    public delegate void EntitySelectedHandler(object sender, EntitySelectedEventArgs args);
    public event EntitySelectedHandler EntitySelected;

    [Range(0f, 9999f)]
    public float TimeBeforeGameStarts = 10.0f;

    [ReadOnly]
    public float timer;
    private bool countdown = true;


    [Range(1, 20)]
    public int spawnInterval = 5;

    public void SelectEntity(GameObject entity)
    {
        EntitySelected?.Invoke(this, new EntitySelectedEventArgs(entity));
    }

    void Start()
    {
        timer = TimeBeforeGameStarts;
        Time.timeScale = 0; // Pause the game simulation
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

}

public class EntitySelectedEventArgs
{

    public bool IsSelected;
    public GameObject SelectedEntity;

    public EntitySelectedEventArgs()
    {
        IsSelected = false;
    }

    public EntitySelectedEventArgs(GameObject selectedEntity)
    {
        SelectedEntity = selectedEntity;
        IsSelected = true;
    }

}