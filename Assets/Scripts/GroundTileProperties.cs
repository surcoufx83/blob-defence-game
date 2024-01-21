using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileProperties : MonoBehaviour
{

    [Range(.0f, 10.0f)]
    public float damagePerSecond = .0f;

    public bool enableBlobSpawn = true;

}
