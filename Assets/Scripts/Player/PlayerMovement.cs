﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movement_speed;
    public Rigidbody2D rigidbody2d;
    Vector2 movement;
    public Animator animator;
    public static float stamina;
    public static bool stamina_regeneration;
    public static float walking_speed;
    public static float running_speed;

    void Awake() {
        walking_speed = PlayerData.secrets.walking_speed;
        running_speed = PlayerData.secrets.running_speed;
        this.movement_speed = walking_speed;
        stamina = PlayerData.secrets.stamina;
        stamina_regeneration = true;
    }

    // Update is called once per frame
    void Update() {
        // returns -1 if left key, 1 for right key
        this.movement.x = Input.GetAxisRaw("Horizontal");
        // returns -1 if down key, 1 up key
        this.movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", this.movement.x);
        animator.SetFloat("Vertical", this.movement.y);
        animator.SetFloat("Speed", this.movement.sqrMagnitude);
    }

    // gets called 50 times a second, better for physics
    // normal Update gets called every frame, bad if frame rate changes
    void FixedUpdate() {
        if (Input.GetButton("Jump") && stamina > 0) {
            stamina -= 0.5f;
            // small buffer so you cant hold space all the time and
            // constantly switch between boosted and normal movement speed
            if (stamina >= 10) {
                this.movement_speed = running_speed;
            } 
        }
        else {
            this.movement_speed = walking_speed;
            if (stamina < PlayerData.secrets.stamina && stamina_regeneration) {
                stamina += 0.5f;
            }
        }
        // moving diagonally returns a magnitude of square root of 2, which would make diagonal movement 40% faster,
        // normalize movement to keep the same speed even when moving diagonally
        this.rigidbody2d.MovePosition(this.rigidbody2d.position + this.movement.normalized * this.movement_speed * Time.fixedDeltaTime);
    }
}
