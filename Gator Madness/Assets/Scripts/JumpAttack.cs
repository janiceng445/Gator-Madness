using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    // Reference CharMove script 
    private CharMove airAttack; 

    // Jumpattack variables
    public bool jumpAttacking = false; 
    public Collider2D jumpAttackTrigger; 

    // Animator 
    private Animator animator; 

    void Awake()
    {
        // Define reference variables for other scripts
        airAttack = gameObject.GetComponent<CharMove>(); 
        animator = gameObject.GetComponent<Animator>(); 

        jumpAttackTrigger.enabled = false; 
    }

    void Update ()
     { 
        // If you press F and you are jumping (bool in CharMove) and you are not jumpattacking yet
        // then you are now jumpattacking 
        if (Input.GetKeyDown("f") && airAttack.jumping && !jumpAttacking)
        {
            jumpAttacking = true;
        }
        // If you are not jumping (bool in CharMove) then you are not jumpattacking 
        if (!airAttack.jumping)
        {
            jumpAttacking = false;
        }
        // Play jumpattack animation based on whether you are jumping or not jumping (bool in CharMove) 
        animator.SetBool("JumpAttack", jumpAttacking); 
     }
}
