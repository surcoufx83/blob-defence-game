using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTileProperties : MonoBehaviour
{

    [Range(.001f, 10.0f)]
    public float movementSpeedFactor = 1.0f;

    public bool movementPossible = true;

    [Range(.0f, 10.0f)]
    public float damagePerSecond = .0f;

}
