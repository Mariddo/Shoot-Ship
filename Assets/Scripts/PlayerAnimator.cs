using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimation();
    }

    void MovementAnimation(){

        animator.SetBool("Moving", rb.velocity.x != 0.0f);
        animator.SetFloat("VelocityHorizontal", rb.velocity.x);
    }
}
