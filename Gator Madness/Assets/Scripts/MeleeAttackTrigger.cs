using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackTrigger : MonoBehaviour
{
    // Is meleeAttacking enabled?
    private MeleeAttack MAttacking; 

    // Damage Integer
    public int Damage = 10; 

    void Awake ()
    {
        // Define referencing variables from other scripts
        MAttacking = gameObject.GetComponent<MeleeAttack>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (MAttacking.attacking)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnemyComp>().DamageEnemy(Damage); 
                Debug.Log ("We hit " + other.gameObject.name + " and did " + Damage + "damage.");
            }
        }
    }
}
