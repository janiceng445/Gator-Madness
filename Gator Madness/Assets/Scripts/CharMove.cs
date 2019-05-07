using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float moveSpeed = 32f;
    public bool isGrounded = false; 
    public Animator animator;

    public CharacterController2D controller;
    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false); 
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            animator.SetBool("isJumping", true); 
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }

    }
    public void onLanding ()
    {
        animator.SetBool("isJumping", false);
    }
}
