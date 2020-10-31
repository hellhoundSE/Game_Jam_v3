using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBehaviour : MonoBehaviour
{
    public GameObject Bullet;

    public float Speed;

    public float Damage;


    public abstract void MakeShoot();
}
