using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static void KillEnemy (EnemyComp enemy) 
    {
        Destroy (enemy.gameObject); 
    }
}
