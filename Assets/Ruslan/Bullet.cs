using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;

    public int damage;

    void Start()
    {
        StartCoroutine(TimeToDestroy());
    }
    private IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            EnemyHealth em = collision.gameObject.GetComponent<EnemyHealth>();
            em.DealDamage(damage);
        }
    }
}
