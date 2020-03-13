using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : BasePlayerController
{

    float xAxisInput;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    private bool jumpInput;
    [SerializeField] Vector2 jumpForce;
    bool isMoving;
    bool isEnterGround;
    [SerializeField] AudioClip landClip;
    [SerializeField] AudioClip jumpClip;
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
    }
    private void FixedUpdate()
    {

        Move();
        Jump();
        CheckForLanding();
    }

    private void CheckForLanding()
    {
        if (IsGrounded && !isEnterGround)
        {
            AudioManager.instance.PlayClip(landClip, 0f);
            //Animator. landing
            isEnterGround = true;
        }
    }

    public override void Move()
    {

        if (xAxisInput == 0)
        {
      
            rb.velocity = new Vector3(0,rb.velocity.x,rb.velocity.z) ;
            isMoving = false;
            return;
        }
        isMoving = true;
        rb.velocity += Vector3.right*xAxisInput * acceleration;// horizontal movement
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMovementSpeed, maxMovementSpeed), rb.velocity.y, rb.velocity.z);
    }
    void Jump()
    {
        if (jumpInput)
        {
          
            if (IsGrounded)
            {

                animator.SetTrigger("Jump");

                rb.velocity += new Vector3(jumpForce.x, jumpForce.y, 0f);
                AudioManager.instance.PlayClip(jumpClip, 0f);
                isEnterGround = false;

            }
        }

    }

    
  
}
