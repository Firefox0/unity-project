using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn_Debuff : Basic_Debuff
{

    private float burn_damage = 0.2f;

    private void Start() {
        this.apply_burn();
    }

    private void Update()
    {
        if (base.has_ended()) {
            Destroy(this.gameObject);
        } else {
            apply_burn();
        }
        followPlayer();
    }

    private void apply_burn() {
        // burn decreases the HP of the player by a small number over time.
        PlayerData.secrets.health -= burn_damage;
    }

    private void followPlayer() {
        // burn effect follows the player
        this.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
