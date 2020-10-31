using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{

    public GunBehaviour Behaviour;

    public int ammo;

    public ShootingTypeEnum shootingType;

    public float chargingTime = 2;

    public abstract void Shoot(GameObject firePoint);
}
