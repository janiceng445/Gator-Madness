using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{
    private CharMove airAttack; 
    public bool jumpAttacking = false; 

   // private float attackTimer = 0; 
   // private float attackCD = 0.05f;

    public Collider2D jumpAttackTrigger; 

    private Animator animator; 

    void Awake()
    {
        airAttack = gameObject.GetComponent<CharMove>(); 
        animator = gameObject.GetComponent<Animator>(); 
        jumpAttackTrigger.enabled = false; 
    }

    void Update ()
     {
        if (Input.GetKeyDown("f") && airAttack.jumping && !jumpAttacking)
        {
            //animator.SetBool("JumpAttack", true);
            jumpAttacking = true;
        }
        if (!airAttack.jumping)
        {
            jumpAttacking = false;
        }
        animator.SetBool("JumpAttack", jumpAttacking); 
     }
}
