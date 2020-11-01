using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public float itemChance;

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
        if(UnityEngine.Random.Range(0.0f, 1.0f) < itemChance)
        {
            int index = (int)UnityEngine.Random.Range(0.0f, GunsLibrary.list.Count);
            GameObject bulletClone = Instantiate(GunsLibrary.prefabs[index]);
            bulletClone.transform.position = transform.position;
            bulletClone.transform.rotation = Quaternion.identity;
        }
    }
}
