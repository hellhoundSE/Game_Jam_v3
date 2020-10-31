using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBehavoiur : GunBehaviour
{
    Vector2 lookDirection;
    float lookAngle;

    public override void MakeShoot(GameObject firePoint)
    {
        //GameObject theBullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
        //Rigidbody2D bulletRigidBody = theBullet.GetComponent<Rigidbody2D>();
        //bulletRigidBody.AddForce(Vector3.forward * Speed);

        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        GameObject bulletClone = Instantiate(Bullet);
        bulletClone.transform.position = firePoint.transform.position;
        bulletClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        bulletClone.GetComponent<Rigidbody2D>().velocity = firePoint.transform.right * Speed;

    }

}
