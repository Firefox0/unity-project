using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    public int health = 1;
    public int gold = 0;

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            this.health -= 0;
        }
    }
}
