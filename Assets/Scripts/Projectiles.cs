using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Projectile {

    public GameObject prefab;
    public float speed;

    public Projectile(GameObject prefab, float speed) {
        this.prefab = prefab;
        this.speed = speed;
    } 
}

/*
public class Homing : Projectile {
    // amount of time to follow player
    public float time;
    public Homing( GameObject prefab, float speed, float time) : base(prefab, speed) {
        this.time = time;
    }
}
*/