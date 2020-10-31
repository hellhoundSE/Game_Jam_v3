﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public Sprite sprite;

    public GunBehaviour Behaviour;

    public int ammo;

    public abstract void Shoot();
}
