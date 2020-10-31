using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Gun Gun;

    public GameObject FirePoint;

    void Update()
    {

        if (Gun != null && IsShootActionDone())
        {
            Gun.Shoot(FirePoint);
        }
    }

    public float laserCharge = 0;
    public bool needToRelease = false;

    private bool IsShootActionDone()
    {
        if (Input.GetMouseButtonUp(0))
        {
            laserCharge = 0;
            needToRelease = false;
        }

        switch (Gun.shootingType)
        {
            case ShootingTypeEnum.Click:
                {
                    return Input.GetMouseButtonDown(0);
                }
            case ShootingTypeEnum.Laser:
                {
                    if (laserCharge > Gun.chargingTime && !needToRelease)
                    {
                        laserCharge = 0;
                        needToRelease = true;
                        return true;
                    }
                    if (Input.GetMouseButton(0))
                        laserCharge += 0.025f;

                }
                break;
        }
        return false;
    }
}
