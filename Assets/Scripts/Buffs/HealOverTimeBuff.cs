using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOverTimeBuff : BuffScript
{

    public float healthPerSecond = 0f;
    public float seconds = 10.0f;

    public override bool Apply(float deltaTime)
    {
        if (gameObject != null)
        {
            Health health = gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.ApplyHeal(healthPerSecond * deltaTime);
                seconds -= deltaTime;
                return seconds > 0;
            }
        }
        return false;
    }

}
