using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    public static int health = 1;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            health -= 1;
        }
    }
}
