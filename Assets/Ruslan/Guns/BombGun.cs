using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGun : Gun
{
    public override void Shoot(GameObject firePoint)
    {
        //ammo and other things is ok
        if (true)
        {
            Behaviour.MakeShoot(firePoint);
        }
    }
}
