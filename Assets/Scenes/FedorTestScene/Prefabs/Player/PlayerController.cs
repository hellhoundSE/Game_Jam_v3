using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;

    private Rigidbody2D rigidbody;

    public float maxAngularVelocity;
    public float speed;
    public float torque;
    public float jumpForce;

    public bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    void AnimatorUpdate()
    {
        float speedThreshold = 0.2f;

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);

            if (Mathf.Abs(rigidbody.velocity.x) > speedThreshold)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }

        if (rigidbody.velocity.x > speedThreshold)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                0,
                transform.rotation.eulerAngles.z);
        }
        if (rigidbody.velocity.x < speedThreshold)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                180,
                transform.rotation.eulerAngles.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorUpdate();
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
        if (Input.GetKey(KeyCode.W))
        {

        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayerByX(-speed * Time.deltaTime, torque * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayerByX(speed * Time.deltaTime, -torque * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void MovePlayerByX(float xValue, float torque)
    {
        if (isGrounded)
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}