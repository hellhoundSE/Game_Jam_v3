using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool stayOnPlatform;
    public bool jumpWithAnInterval = true;

    private GameObject player;
    public float distanceThreshold;
    private float distanceToPlayer;

    public Transform topRay;
    public Transform leftRay;
    public Transform middlRay;
    public Transform rightRay;
    public float isGroundedThreshold = 1.5f;
    public float isUnderPlatformTheshold = 2;

    public GameObject hitObject;
    private float distanceToHit;

    private Rigidbody2D rigidbody;
    public const float jumpTimer = 2;
    public float jumpTimer_; 
    public float jumpForce;
    public float normalSpeed;
    public float followingSpeed;

    public int decreaseHealthBy = 1; // health taken from player on collision

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

        //GroundRaycast();

        if (distanceToPlayer < distanceThreshold)
            FollowPlayer();


        EnemyJump();
    }

    bool IsRayOnGround(Transform rayTransform)
    {
        return GetHitDistance(rayTransform) < isGroundedThreshold;
    }


    void EnemyJump()
    {
        if (!jumpWithAnInterval)
            return;

        if (jumpTimer_ <= 0)
        {
            float d = GetHitDistance(topRay, Vector2.up);
            if (d == -1)
                d = Mathf.Infinity;
            Debug.Log(d);
            if (d > isUnderPlatformTheshold)
            {
                ///
                rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                ///
            }

            jumpTimer_ = jumpTimer;

            return;
        }
        else
        {
            jumpTimer_ -= Time.deltaTime;
        }
    }

    //void GroundRaycast()
    //{
    //    GetHitDistance(leftRay);
    //    GetHitDistance(middlRay);
    //    GetHitDistance(rightRay);
    //}

    float GetHitDistance(Transform origin, Vector2? direction = null)
    {
        if (direction == null)
            direction = -Vector2.up;

        RaycastHit2D hit = Physics2D.Raycast(origin.position, (Vector2)direction);

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
            if (IsRayOnGround(leftRay) || !stayOnPlatform)
            {
                MovePlayerByX(-followingSpeed * Time.deltaTime);
            }
        }
        if (player.transform.position.x > transform.position.x)
        {
            if (IsRayOnGround(rightRay) || !stayOnPlatform)
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