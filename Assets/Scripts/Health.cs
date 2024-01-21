using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [Range(0, 1000)]
    public float health = 100.0f;

    [Range(0, 1000)]
    public float maxHealth = 100.0f;

    public List<BuffScript> buffs = new List<BuffScript>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
            return;
        for (int i = buffs.Count - 1; i >= 0; i--)
        {
            bool result = buffs[i].Apply(Time.deltaTime);
            if (!result)
            {
                buffs.RemoveAt(i);
            }
        }
        if (health <= 0)
        {
            health = 0;
            gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            Destroy(gameObject, 5f);
        }
    }

    public void ApplyHeal(float heal)
    {
        this.health = Mathf.Clamp(this.health + heal, 0, maxHealth);
    }

}
