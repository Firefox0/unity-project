﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Debuff : Basic_Debuff
{
    public float slow_percentage;
    protected float slow_factor;

    private void Start() {
        this.apply_debuff();
    }

    private void Update() {
        if (base.has_ended()) {
            this.reset_speed();
            Destroy(this.gameObject);
        }
        followPlayer();
    }

    private void reset_speed() {
        PlayerMovement.walking_speed = PlayerData.secrets.walking_speed;
        PlayerMovement.running_speed = PlayerData.secrets.running_speed;
    }

    private void apply_debuff() {
        // only apply slow if its stronger/equal than the current one (if there are any)
        float temp_walking_speed = PlayerData.secrets.walking_speed * this.slow_factor;
        if (temp_walking_speed <= PlayerMovement.walking_speed) {
            PlayerMovement.walking_speed = temp_walking_speed;
            PlayerMovement.running_speed = PlayerData.secrets.running_speed * this.slow_factor;
        }
    }

    private void followPlayer() {
        // burn effect follows the player
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
