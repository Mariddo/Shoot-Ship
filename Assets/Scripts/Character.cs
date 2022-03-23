using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float hitPoints;

    void Update() {

        CheckForDeath();
    }

    protected void CheckForDeath() {

        if(hitPoints <= 0f)
        {
            Die();
        }
    }

    protected void Die() {
        Destroy(gameObject);
    }

    protected void TakeDamage(float damage) {

        hitPoints -= damage;
        CheckForDeath();
    }
}
