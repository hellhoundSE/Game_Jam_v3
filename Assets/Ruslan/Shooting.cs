using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Gun Gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Gun.Shoot();
        }   
    }
}
