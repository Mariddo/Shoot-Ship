using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    Collider2D collider;

    public GameObject explosionEffect;

    public float damage;

    public GameObject afterImage;
    public float afterImageDuration= 0.25f;
    public float afterImageDelay = 0.1f;

    public bool effectOnDestroy;
    [HideInInspector]public float destroyLifespan;

    public float effectDamage;

    Coroutine afterImageCoroutine, destroyCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();

        if(afterImage != null)
        {
            afterImageCoroutine = StartCoroutine(AfterImage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(effectOnDestroy && destroyCoroutine == null) {
            destroyCoroutine = StartCoroutine(BoomEffect());
        }
    }

    public void Hit()
    {
        if(explosionEffect != null)
        {
            
            var explodeEffect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

            explodeEffect.GetComponent<ExplodeBehavior>().damage = effectDamage;
        }

        Destroy(gameObject);

    }

    IEnumerator AfterImage() {

        while(true) {
            var afterImageObject = Instantiate(afterImage,transform.position,Quaternion.identity);

            Destroy(afterImageObject, afterImageDuration);

            yield return new WaitForSeconds(afterImageDelay);  
        }

    }

    IEnumerator BoomEffect() {

        yield return new WaitForSeconds(destroyLifespan);

        Hit();
    }

}
