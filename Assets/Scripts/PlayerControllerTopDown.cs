using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTopDown : BasePlayerController
{
    [SerializeField] float xAxisInput, zAxisInput;
    bool jumpInput;
    [SerializeField] Vector3 jumpForce;
    bool isEnterGround;
    [SerializeField]AudioClip onLandClip;
    [SerializeField] AudioClip jumpClip;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
        CheckForLanding();
    }
    void Update()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        zAxisInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetButtonDown("Jump");
    }
    public override void Move()
    {

        if (xAxisInput == 0 || zAxisInput == 0)
        {
            Vector3 finaVelocity;
            finaVelocity = rb.velocity;
            finaVelocity.x = 0f;
            finaVelocity.z = 0f;
            rb.velocity = finaVelocity;
            return;
           
        }

        rb.velocity += new Vector3(xAxisInput, 0f, zAxisInput) * movementSpeed;
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxMovementSpeed, maxMovementSpeed), rb.velocity.y,
            Mathf.Clamp(rb.velocity.z, -maxMovementSpeed, maxMovementSpeed));
    }
    void Jump()
    {
        if (jumpInput)
        {

            if (IsGrounded)
            {

                animator.SetTrigger("Jump");

                rb.velocity += new Vector3(jumpForce.x, jumpForce.y, 0f);
                isEnterGround = false;
                AudioManager.instance.PlayClip(jumpClip, 0f);

            }
        }

    }
    private void CheckForLanding()
    {
        if (IsGrounded && !isEnterGround)
        {
            AudioManager.instance.PlayClip(onLandClip, 0f);
            //Animator. landing
            isEnterGround = true;
        }
    }

    
}
