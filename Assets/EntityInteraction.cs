using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EntityInteraction : MonoBehaviour
{

    public GameControllerScript gameController;
    private Camera mainCamera;

    public bool showEntityInfoOnClick;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void OnMouseUpAsButton()
    {
        Debug.Log($"OnMouseUpAsButton()");
        if (showEntityInfoOnClick)
        {
            gameController?.SelectEntity(gameObject);
        }
    }

    void OnMouseDown()
    {
        Debug.Log($"OnMouseDown()");
        if (showEntityInfoOnClick)
        {
            gameController?.SelectEntity(gameObject);
        }
    }

    void OnMouseUp()
    {
        Debug.Log($"OnMouseUp()");
        if (showEntityInfoOnClick)
        {
            gameController?.SelectEntity(gameObject);
        }
    }

    void UnityApiMouseEvents()
    {
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.rigidbody != null)
                hit.rigidbody.gameObject.SendMessage("OnMouseDown");
            else
                hit.collider.SendMessage("OnMouseDown");
        }

    }

}
