using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityUiController : MonoBehaviour
{

    public GameControllerScript gameController;

    public Text titleTextBox;

    // Start is called before the first frame update
    void Start()
    {
        gameController.EntitySelected += GameController_EntitySelected;
    }

    private void GameController_EntitySelected(object sender, EntitySelectedEventArgs args)
    {
        Debug.Log($"Entity {args.SelectedEntity} selected");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
