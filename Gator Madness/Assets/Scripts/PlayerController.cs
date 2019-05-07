/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    private Rigidbody2D rb2d;
    private float moveHorizontal = 0f;
    private float moveVertical = 0f;
    private CharacterController2D controller;

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController2D>();
    }

    void Update() {
    }

    void FixedUpdate() {
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical = Input.GetAxis("Vertical") * speed;
        controller.Move(moveHorizontal * Time.fixedDeltaTime, moveVertical * Time.fixedDeltaTime);
    }

}  */
