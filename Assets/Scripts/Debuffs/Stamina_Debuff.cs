using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina_Debuff : Basic_Debuff {

    // how much stamina to lose every 1/50th of a second
    public float stamina_debuff;

    private void Start() {
        // ignore if there is already a stamina debuff 
        if (!PlayerMovement.stamina_regeneration) {
            Destroy(this.gameObject);
        }
        else {
            PlayerMovement.stamina_regeneration = false;
        }
    }

    private void Update() {
        if (base.has_ended()) {
            PlayerMovement.stamina_regeneration = true;
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate() { 
        PlayerMovement.stamina -= stamina_debuff;
    }
}
