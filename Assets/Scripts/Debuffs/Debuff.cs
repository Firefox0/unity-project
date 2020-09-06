using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuff : MonoBehaviour {

    public GameObject debuff;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            Instantiate(debuff);
        }
    }
}
