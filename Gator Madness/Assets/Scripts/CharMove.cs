﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private MeleeAttack meleeAttacking; 

    public float moveSpeed = 35f;
    public bool isGrounded = false; 
    public bool jumping = false; 
    public Animator animator;

    public CharacterController2D controller;
    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        meleeAttacking = gameObject.GetComponent<MeleeAttack>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        if (!meleeAttacking.attacking)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        }
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
        if (Input.GetButtonDown("Jump") && isGrounded == true && !meleeAttacking.attacking)
        {
            jumping = true;
            animator.SetBool("isJumping", true); 
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

    }
    public void onLanding ()
    {
        animator.SetBool("isJumping", false);
        jumping = false; 
    }
}
