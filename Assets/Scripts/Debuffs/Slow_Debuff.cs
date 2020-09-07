using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Debuff : Basic_Debuff {

    public float slow_percentage;

    private void Start() {
        this.apply_slow();
    }

    private void Update() {
        if (base.has_ended()) {
            this.reset_speed();
            Destroy(this.gameObject);
        }
    }
    private float slow_factor() {
        return 1 - this.slow_percentage / 100;
    }

    private void reset_speed() {
        PlayerMovement.walking_speed = PlayerData.secrets.walking_speed;
        PlayerMovement.running_speed = PlayerData.secrets.running_speed;
    }

    private void apply_slow() {
        // only apply slow if its stronger/equal than the current one (if there are any)
        float temp_walking_speed = PlayerData.secrets.walking_speed * this.slow_factor();
        if (temp_walking_speed <= PlayerMovement.walking_speed) {
            PlayerMovement.walking_speed = temp_walking_speed;
            PlayerMovement.running_speed = PlayerData.secrets.running_speed * this.slow_factor();
        }
    }
}
