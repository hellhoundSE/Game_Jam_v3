using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunBehavoiur : GunBehaviour
{
    public void FixedUpdate()
    {

    }
    public override void MakeShoot()
    {

        GameObject theBullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D bulletRigidBody = theBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(Vector3.forward * Speed);


    }

}
