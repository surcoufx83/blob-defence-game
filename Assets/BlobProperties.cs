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
    public int health;

    [Range(0, 1000)]
    public int damage;

    [Range(0, 100)]
    public float attackRange;

    public WizardPower power = WizardPower.None;

}
