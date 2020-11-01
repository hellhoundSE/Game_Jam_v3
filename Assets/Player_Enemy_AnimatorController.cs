using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Enemy_AnimatorController : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorUpdate();
    }

    void AnimatorUpdate()
    {
        float speedThreshold = 0.2f;

        // flip by y axis depending on player`s direction
        if (rigidbody.velocity.x < -speedThreshold)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                180,
                transform.rotation.eulerAngles.z);
        }
        
        if (rigidbody.velocity.x > speedThreshold)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                0,
                transform.rotation.eulerAngles.z);
        }


        if (rigidbody.velocity.x < 0.0001f && rigidbody.velocity.x > -0.0001f)
        {
            animator.SetBool("isWalking", false);
        }
        else {
            animator.SetBool("isWalking", true);
        }
    }
}
