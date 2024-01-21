using UnityEngine;

public enum BlobType
{
    Basic,
    StoneThrower,
    Wizard
}

public enum WizardPower { 
    None, 
    Fire, 
    Water, 
    Ice, 
    Air, 
    Earth, 
    Thunder
}

public class BlobProperties : MonoBehaviour
{

    public BlobType type;

    [Range(0, 1000)]
    public int damage = 10;

    [Range(0, 100)]
    public float attackRange = 0f;

    [Range(0f, 1f)]
    public float baseMovementSpeed = .5f;

    [Range(0f, 2f)]
    public float rageMovementSpeed = 1f;

    public bool rageModeActive = false;

    public WizardPower power = WizardPower.None;

}
