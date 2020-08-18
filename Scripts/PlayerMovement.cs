using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movement_speed = 5f;
    public Rigidbody2D rigidbody;
    Vector2 movement;

    // Update is called once per frame
    void Update() {
        // returns 0 if left key, 1 for right key
        this.movement.x = Input.GetAxisRaw("Horizontal");
        // returns 0 if down key, 1 up key
        this.movement.y = Input.GetAxisRaw("Vertical");
    }

    // gets called 50 times a second, better for physics
    // normal Update gets called every frame, bad if frame rate changes
    void FixedUpdate() {
        this.rigidbody.MovePosition(this.rigidbody.position + this.movement * this.movement_speed * Time.fixedDeltaTime);
    }
}
