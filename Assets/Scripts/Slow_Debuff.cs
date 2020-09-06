using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Debuff : MonoBehaviour {

    public float slow_time;
    public float slow_percentage;

    private void Start() {
        this.apply_slow();
    }

    private void Update() {
        this.slow_time -= Time.deltaTime;
        if (this.slow_time <= 0) {
            // reset speed 
            PlayerMovement.walking_speed = PlayerData.secrets.walking_speed;
            PlayerMovement.running_speed = PlayerData.secrets.running_speed;
            Destroy(this.gameObject);
        }
    }

    private float slow_factor() {
        return 1 - this.slow_percentage / 100;
    }

    public void apply_slow() {
        // only apply slow if its stronger/equal than the current one (if there are any)
        float temp_walking_speed = PlayerData.secrets.walking_speed * this.slow_factor();
        if (temp_walking_speed <= PlayerMovement.walking_speed) {
            PlayerMovement.walking_speed = temp_walking_speed;
            PlayerMovement.running_speed = PlayerData.secrets.running_speed * this.slow_factor();
        }
    }
}
