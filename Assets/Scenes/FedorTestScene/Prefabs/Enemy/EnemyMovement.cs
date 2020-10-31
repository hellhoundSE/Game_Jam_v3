using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float distanceThreshold;
    public float distanceToPlayer;

    public Transform leftRay;
    public Transform middlRay;
    public Transform rightRay;

    public GameObject hitObject;
    public float distanceToHit;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        GroundRaycast();

        if (distanceToPlayer < distanceThreshold)
            FollowPlayer();
    }

    void GroundRaycast()
    {
        GetHitDistance(leftRay);
        GetHitDistance(middlRay);
        GetHitDistance(rightRay);
    }

    float GetHitDistance(Transform origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, -Vector2.up);

        if (hit.collider != null)
        {
            hitObject = hit.collider.gameObject;
            distanceToHit = Vector2.Distance(new Vector2(origin.position.x, origin.position.y), hit.point);
            return distanceToHit;
        }

        return -1;
    }

    void FollowPlayer()
    { 
        
    }
}