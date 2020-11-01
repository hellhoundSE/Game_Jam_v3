using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health;

    public void DealDamage(int damage)
    {
        health -= damage;

        if(health <=0)
        {
            DropOtem();
            Destroy(gameObject);
        }
    }

    private void DropOtem()
    {
        Debug.Log("drop");
    }
}
