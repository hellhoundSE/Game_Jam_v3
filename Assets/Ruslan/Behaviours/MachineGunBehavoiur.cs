using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBehavoiur : GunBehaviour
{

    public override void MakeShoot()
    {
        GameObject theBullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D bulletRigidBody = theBullet.GetComponent<Rigidbody2D>();
        bulletRigidBody.AddForce(Vector3.forward * Speed);
    }

}
