using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movement_speed = 5f;
    public Rigidbody2D rigidbody;
    Vector2 movement;
    public Animator animator;

    // Update is called once per frame
    void Update() {
        // returns -1 if left key, 1 for right key
        this.movement.x = Input.GetAxisRaw("Horizontal");
        // returns -1 if down key, 1 up key
        this.movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", this.movement.x);
        animator.SetFloat("Vertical", this.movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // gets called 50 times a second, better for physics
    // normal Update gets called every frame, bad if frame rate changes
    void FixedUpdate() {
        // moving diagonally returns a magnitude of square root of 2, which would make diagonal movement 40% faster,
        // normalize movement to keep the same speed even when moving diagonally
        this.rigidbody.MovePosition(this.rigidbody.position + this.movement.normalized * this.movement_speed * Time.fixedDeltaTime);
    }
}
