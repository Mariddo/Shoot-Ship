using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    Collider2D collider;

    public GameObject explosionEffect;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit()
    {
        if(explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

    }

}
