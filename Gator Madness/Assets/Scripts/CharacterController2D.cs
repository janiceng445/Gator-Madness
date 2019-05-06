using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float smoothing = .05f;
    private Rigidbody2D rbd2;
    private Vector3 zero_velocity = Vector3.zero;
    private bool facingRight = true;

    void Start() {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    public void Move(float x, float y) {
        // Change velocity
        Vector3 target_velocity = new Vector3(x * 10f, y * 10f);
        
        // Smooth velocity and update
        rbd2.velocity = Vector3.SmoothDamp(rbd2.velocity, target_velocity, ref zero_velocity, smoothing);

        // Look left
        if (x < 0 && facingRight) {
            Flip();
        }
        // Look right
        else if (x > 0 && !facingRight) {
            Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
