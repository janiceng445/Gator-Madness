using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    // Referencing other scripts 
    private CharMove groundAttack; 

    // meleeAttacking variables
    public bool attacking = false;

    // Cooldowns to not attack every spam F
    private float attackTimer = 0;
    private float attackCD = 0.7f; 

    public Collider2D meleeAttackTrigger; 
    
    // Animator
    private Animator animator; 

    void Awake()
    {
        // Define reference variables for other scripts 
        groundAttack = gameObject.GetComponent<CharMove>(); 
        animator = gameObject.GetComponent<Animator>(); 
        meleeAttackTrigger.enabled = false;
    }

    void Update ()
    {
        // If you press F and you are not jumping (from CharMove) and you are not attacking yet
        // then you are now attacking 
        if (Input.GetKeyDown("f") && !groundAttack.jumping && !attacking) 
        {
            attacking = true; 
           
            attackTimer = attackCD;

            meleeAttackTrigger.enabled = true; 
        }
        // If you are now attacking, then the timer is equal to the cooldown. 
        // If it is greater than 0 then it will decrease until it is
        // Once it is less than 0 then we are no longer attacking and set animation false. 
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                meleeAttackTrigger.enabled = false; 
            }
        }

        animator.SetBool("MeleeAttack", attacking); 
    }
}
