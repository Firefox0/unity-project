using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Projectile : Basic_Projectile {
    private GameObject target;
    private Rigidbody2D rigidbody_;
    public float rotation_speed;
    public float time; 

    void Start() {
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.rigidbody_ = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        this.time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate() {
        Vector2 direction = (Vector2)transform.position - (Vector2)target.transform.position;
        direction.Normalize();
        float rotation_value = Vector3.Cross(direction, this.transform.up).z;
        this.rigidbody_.angularVelocity = rotation_value * this.rotation_speed;
        this.rigidbody_.velocity = this.transform.up * this.speed;
    }
}
