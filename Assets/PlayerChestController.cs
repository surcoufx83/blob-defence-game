using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChestController : MonoBehaviour
{

    public GameObject[] chestPrefabs;
    public GameController controller;

    // Start is called before the first frame update
    void Start()
    {
        if (controller != null && chestPrefabs.Length > 0)
        {
            GameObject chest = Instantiate(chestPrefabs[Random.Range(0, chestPrefabs.Length)], transform.position, Quaternion.identity, transform);
            chest.transform.localScale *= .2f;
            controller.PlayerChest = chest;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
