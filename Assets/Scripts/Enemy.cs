using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDeath();
    }

    void OnCollisionEnter2D(Collision2D other) {

        if(other.transform.tag == "PlayerBullet")
        {
            Debug.Log("HIT!");

            BulletBehavior bb = other.transform.GetComponent<BulletBehavior>();

            bb.Hit();

            TakeDamage(bb.damage);
        }
    }
}
