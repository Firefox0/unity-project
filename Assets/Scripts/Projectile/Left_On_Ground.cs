using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_On_Ground : MonoBehaviour {
    public float time;
    void Update() {
        time -= Time.deltaTime;
        if (time <= 0) {
            Destroy(this.gameObject);
        }
    }
}
