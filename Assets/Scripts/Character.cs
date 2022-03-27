using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float hitPoints;

    protected void CheckForDeath() {

        if(hitPoints <= 0f)
        {
            Die();
        }
    }

    protected abstract void Die();
}
