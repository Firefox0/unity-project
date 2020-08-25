using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Projectile : Basic_Projectile {
    // time to leave stuff on the ground
    public GameObject left_on_ground;
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            Instantiate(left_on_ground, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}