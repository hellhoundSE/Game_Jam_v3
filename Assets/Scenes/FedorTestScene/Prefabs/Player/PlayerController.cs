using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    //private Animator animator;

    public Transform[] groundRays;
    public float averageDistanceOnLastFrame;
    public float averageDistanceOnThisFrame;
    public float avgDistanceDelta;
    public float isGroundedDistanceThreshold;
    public bool isGoingDown;

    private Rigidbody2D rigidbody;
    private float initialLinearDrag;
    public float dragWhenGrounded;

    public float maxAngularVelocity;
    public float speed;
    public float flyingSpeed;
    private float currentMaxSpeed;
    public float torque;
    public float jumpForce;

    public bool isGrounded = true;

    public int health = 10;
    Shooting shooting;

    public  bool isKeyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        shooting = GetComponent<Shooting>();
        rigidbody = GetComponent<Rigidbody2D>();
        initialLinearDrag = rigidbody.drag;
        //animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        ClampAngularVelocity();
    }

    void ClampAngularVelocity()
    {
        if (rigidbody.angularVelocity < -maxAngularVelocity) { rigidbody.angularVelocity = -maxAngularVelocity; }
        if (rigidbody.angularVelocity > maxAngularVelocity) { rigidbody.angularVelocity = maxAngularVelocity; }
    }

    //void AnimatorUpdate()
    //{
    //    float speedThreshold = 0.2f;

    //    // flip by y axis depending on player`s direction
    //    if (rigidbody.velocity.x < -speedThreshold)
    //    {
    //        transform.rotation = Quaternion.Euler(
    //            transform.rotation.eulerAngles.x,
    //            180,
    //            transform.rotation.eulerAngles.z);

    //        return;
    //    }

    //    if (rigidbody.velocity.x > speedThreshold)
    //    {
    //        transform.rotation = Quaternion.Euler(
    //            transform.rotation.eulerAngles.x,
    //            0,
    //            transform.rotation.eulerAngles.z);

    //        return;
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        isKeyPressed = Input.GetKey(KeyCode.X);

        IsGrounded();
        //AnimatorUpdate();
        Movement();

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            maxAngularVelocity *= 2;
            speed *= 2;
            torque *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            maxAngularVelocity /= 2;
            speed /= 2;
            torque /= 2;
        }
    }


    void Movement()
    {
        if (isGrounded)
        {
            currentMaxSpeed = speed;
        }
        if (!isGrounded)
        {
            currentMaxSpeed = flyingSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayerByX(-currentMaxSpeed * Time.deltaTime, torque * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayerByX(currentMaxSpeed * Time.deltaTime, -torque * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MovePlayerByX(float xValue, float torque)
    {
        //if (isGrounded)
        {
            rigidbody.AddForce(new Vector2(xValue, 0));
            rigidbody.AddTorque(torque);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            rigidbody.drag = initialLinearDrag;
        }
    }


    void IsGrounded()
    {
        averageDistanceOnThisFrame = 0;
        bool solved = false;
        foreach (Transform groundRay in groundRays)
        {
            if (IsGrounded(groundRay))
                solved = true;
        }

        switch (solved)
        {
            case true:
                if (isGoingDown)
                {
                    isGrounded = true;
                    rigidbody.drag = dragWhenGrounded;
                }
                break;
            case false:
                isGrounded = false;
                rigidbody.drag = initialLinearDrag;
                break;
        }

        averageDistanceOnThisFrame /= groundRays.Length;
        avgDistanceDelta = averageDistanceOnLastFrame - averageDistanceOnThisFrame;
        if (avgDistanceDelta > 0.01f)
        {
            isGoingDown = true;
            //Debug.Log("Down");
        }
        else
            isGoingDown = false;
        averageDistanceOnLastFrame = averageDistanceOnThisFrame;
    }


    bool IsGrounded(Transform origin)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin.position, -Vector2.up);

        //if (hit.collider != null && hit.collider.tag == "Ground")
        if (hit.collider != null)
        {
            float distance = Vector2.Distance(new Vector2(origin.position.x, origin.position.y), hit.point);
            averageDistanceOnThisFrame += distance;
            //Debug.Log(distance);
            if (distance < isGroundedDistanceThreshold)
                return true;
        }

        return false;
    }


    public void DecreaseHealth(int decreaseBy = 1)
    {
        health -= decreaseBy;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    isGrounded = true;
    //    rigidbody.drag = dragWhenGrounded;
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Before");

        if (collision.transform.tag == "Gun" && isKeyPressed)
        {
            Debug.Log("Pick");
            Gun g = collision.gameObject.GetComponent<Gun>();
            shooting.Gun = g; 
        }
    }
}