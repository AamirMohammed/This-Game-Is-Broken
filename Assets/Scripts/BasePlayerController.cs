using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlayerController: MonoBehaviour
{
    public Animator animator;
    protected Rigidbody rb;
    [SerializeField] protected float maxMovementSpeed;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected Transform groundChecker;
    [SerializeField] protected float rayCastDistance;
    [SerializeField] protected LayerMask groundLayer;
    public virtual bool IsGrounded
    {
        get
        {
            return Physics.Raycast(groundChecker.position, Vector3.down, rayCastDistance, groundLayer);
        }
       
    }
    public abstract void Move();
    
}
