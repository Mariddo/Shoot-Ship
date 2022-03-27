using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBehavior : MonoBehaviour
{
    public float isFiring;

    public float timer;

    public Weapon weapon;

    public List<Transform> gunPorts;

    int gunPortCounter;

    Coroutine firingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        isFiring = 0;
        timer = 0;

        gunPortCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFiring > 0)
        {
            timer += Time.deltaTime;
        }
        else{
            timer = 0f;
        }

        Fire();
    }

    void Fire(){

        if(isFiring > 0 && firingCoroutine == null && weapon != null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());

        }
        else if (isFiring <= 0 && firingCoroutine != null){

            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }

    IEnumerator FireContinuously()
    {
        while(true)
        {

            if(weapon.shootingPattern == ShootingPattern.Organ) {

                Transform gunPort = gunPorts[gunPortCounter];

                FireGun(gunPort);

                if(gunPortCounter >= gunPorts.Capacity-1)
                {
                    gunPortCounter = 0;
                }
                else
                {
                    gunPortCounter++;
                }
                

            }
            else if (weapon.shootingPattern == ShootingPattern.All) {

                foreach (var gunPort in gunPorts) {
                    
                    FireGun(gunPort);

                }
            }


        
            yield return new WaitForSeconds(weapon.fireDelay);
        }
    }

    void FireGun(Transform gunPort) {

                GunPort gunPortCode = gunPort.GetComponent<GunPort>();

                GameObject instance = Instantiate(weapon.bullet, 
                                        gunPort.transform.position, 
                                        Quaternion.identity);

                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

                SpriteRenderer sr = instance.GetComponent<SpriteRenderer>();

                sr.flipX = gunPortCode.flipBulletX;


                BulletBehavior bb = instance.GetComponent<BulletBehavior>();
                bb.damage = weapon.contactDamage;
                bb.effectDamage = weapon.secondaryDamage;

                if(rb != null)
                {
                     rb.velocity = transform.up * weapon.projectileSpeed;
                }

                if(weapon.explodeOnDestroy) {
                    bb.effectOnDestroy = true;
                    bb.destroyLifespan = weapon.projectileLifetime;
                    bb.effectDamage = weapon.secondaryDamage;
                }
                else {
                    Destroy(instance, weapon.projectileLifetime);
                }
                

    }

}
