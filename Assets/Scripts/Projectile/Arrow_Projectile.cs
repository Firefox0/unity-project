using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Arrow_Projectile : Basic_Projectile {
    
    // Start is called before the first frame update
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
        
    }

    /*void travel(float velocity, Vector2 direction) {
        this.GetComponent<Rigidbody2D>().velocity = direction * velocity;
    }
    void flyToDirection(Vector2 direction) {
        this.GetComponent<Rigidbody2D>().velocity = direction;
        //this.transform.Rotate(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }*/

}
