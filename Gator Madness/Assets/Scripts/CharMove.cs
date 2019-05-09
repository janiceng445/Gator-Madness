using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    // Reference other scripts
    private MeleeAttack meleeAttacking; 
    private JumpAttack airAttacking; 

    // Moving variables
    public float moveSpeed = 35f;
    public bool isGrounded = false; 
    public bool jumping = false; 
    public CharacterController2D controller;
    float horizontalMove = 0f;

    // Animator 
    public Animator animator;

    void Start()
    {
        // Define reference variables for other scripts
        meleeAttacking = gameObject.GetComponent<MeleeAttack>(); 
        airAttacking = gameObject.GetComponent<JumpAttack>(); 
    }

    void Update()
    {
        Jump();


        // If you are not meleeAttacking, you can move left and right
        if (!meleeAttacking.attacking)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        }
        // Otherwise, you cannot move if you are meleeAttacking. 
        else if (meleeAttacking.attacking)
        {
            horizontalMove = 0;
        }
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false); 
    }
    void Jump()
    {
        // If you press key (Jump) and you are on the ground and you are not attacking, then you may jump
        if (Input.GetButtonDown("Jump") && isGrounded == true && !meleeAttacking.attacking)
        {
            jumping = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,7f), ForceMode2D.Impulse);
        }
        // If you are jumping and are not jumpAttacking, then the animation for regular jump plays
        if (jumping && !airAttacking.jumpAttacking)
        {
            animator.SetBool("isJumping", true);
        }
    }

    // Once the animation ends on the last frame, then this function tells the animation to stop on the loop. 
    public void onLanding ()
    {
        animator.SetBool("isJumping", false);
        jumping = false; 
    }
}
