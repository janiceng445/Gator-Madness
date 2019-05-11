using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignoreCollision : MonoBehaviour
{
    void Update ()
    {
        //Physics2D.IgnoreLayerCollision (8, 10);
        Physics2D.IgnoreLayerCollision (10,10);
    }
}
