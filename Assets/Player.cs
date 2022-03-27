using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public HitPoints hitPoints;

    public float maxHitPoints = 1.0f;

    public GameObject deathPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(hitPoints != null) {

            hitPoints.value = maxHitPoints;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {

        if(other.transform.tag == "Enemy") {

            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            Hit(enemy.collisionDamage);
        }
        else if(other.transform.tag == "EnemyBullet") {


        }
    }

    void Hit(float damage){
        hitPoints.value -= damage;

        if(hitPoints.value <= 0) {

            DeathAnimation();
        }

    }

    void DeathAnimation() {

        Instantiate(deathPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
