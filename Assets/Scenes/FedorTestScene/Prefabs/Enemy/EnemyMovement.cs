using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float distanceThreshold;
    private float distanceToPlayer;

    public Transform leftRay;
    public Transform middlRay;
    public Transform rightRay;
    public float isGroundedThreshold = 1.5f;

    public GameObject hitObject;
    private float distanceToHit;

    private Rigidbody2D rigidbody;
    public float normalSpeed;
    public float followingSpeed;

    public int decreaseHealthBy = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        GroundRaycast();

        if (distanceToPlayer < distanceThreshold)
            FollowPlayer();
    }

    bool IsRayOnGround(Transform rayTransform)
    {
        return GetHitDistance(rayTransform) < isGroundedThreshold;
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
        if (player.transform.position.x < transform.position.x)
        {
            if (IsRayOnGround(leftRay))
            {
                MovePlayerByX(-followingSpeed * Time.deltaTime);
            }
        }
        if (player.transform.position.x > transform.position.x)
        {
            if (IsRayOnGround(rightRay))
            {
                MovePlayerByX(followingSpeed * Time.deltaTime);
            }
        }
    }

    void MovePlayerByX(float xValue)
    {
        rigidbody.AddForce(new Vector2(xValue, 0));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.gameObject.GetComponent<PlayerController>().DecreaseHealth(decreaseHealthBy);
        }
    }
}