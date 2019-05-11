using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackTrigger : MonoBehaviour
{
    // Damage Integer
    public int Damage = 50; 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyComp>().DamageEnemy(Damage); 
            Debug.Log ("We hit " + other.gameObject.name + " and did " + Damage + " damage.");
        }
    }
}
