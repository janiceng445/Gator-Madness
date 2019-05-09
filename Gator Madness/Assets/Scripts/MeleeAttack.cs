using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private CharMove groundAttack; 
    public bool attacking = false;

    private float attackTimer = 0;
    private float attackCD = 0.7f; 

    public Collider2D meleeAttackTrigger; 
    
    private Animator animator; 

    void Awake()
    {
        groundAttack = gameObject.GetComponent<CharMove>(); 
        animator = gameObject.GetComponent<Animator>(); 
        meleeAttackTrigger.enabled = false;
    }

    void Update ()
    {
        if (Input.GetKeyDown("f") && !groundAttack.jumping && !attacking) 
        {
            attacking = true; 
           
            attackTimer = attackCD;

            meleeAttackTrigger.enabled = true; 
        }
        
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
