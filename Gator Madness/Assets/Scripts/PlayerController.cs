using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D m_Rigidbody2D; 
    public float speed = 50f;
    float horizontalMove = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed; 
    }
    void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
    }
    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move + 10f, m_Rigidbody2D.velocity.y);
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}   
