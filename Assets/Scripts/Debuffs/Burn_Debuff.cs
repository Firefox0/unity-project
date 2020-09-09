using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn_Debuff : Basic_Debuff
{

    private float burn_damage = 0.2f;
    private GameObject player;

    private void Start() {
        // save player, because having to find it all the time is inefficient
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (base.has_ended()) {
            Destroy(this.gameObject);
        }
         follow_player();
    }

    private void FixedUpdate() {
        PlayerHit.health -= burn_damage;
    }

    private void follow_player() {
        // burn effect follows the player
        this.transform.position = this.player.transform.position;
    }
}
