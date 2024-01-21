using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeBuff : BuffScript
{

    public float damagePerSecond = 0f;
    public float seconds = 10.0f;

    public override bool Apply(float deltaTime)
    {
        if (gameObject != null)
        {
            Health health = gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.ApplyHeal(-damagePerSecond * deltaTime);
                seconds -= deltaTime;
                return seconds > 0;
            }
        }
        return false;
    }

}
