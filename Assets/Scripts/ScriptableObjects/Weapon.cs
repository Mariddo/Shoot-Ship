using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingPattern{All, Organ};

public enum FirePattern{Semi, Auto};

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    public float fireDelay;

    public ShootingPattern shootingPattern;

    public GameObject bullet;

    public float projectileSpeed = 8f;

    public float projectileLifetime = 0.5f;

    public float contactDamage = 1f;

    public float secondaryDamage = 0f;

    public bool explodeOnDestroy = false;

}


