using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_Debuff : Basic_Debuff
{

    private float poison_damage = 0.1f;
    private float stamina_drain = 0.2f;
    private GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement.stamina_regeneration = false;
    }

    private void Update() {
        if (base.has_ended()) {
            PlayerMovement.stamina_regeneration = true;
            Destroy(this.gameObject);
        }
        follow_player();
    }

    private void FixedUpdate() {
        PlayerHit.health -= poison_damage;
        PlayerMovement.stamina -= stamina_drain;
    }
    private void follow_player() {
        // poison effect follows the player
        this.transform.position = this.player.transform.position;
    }
}
