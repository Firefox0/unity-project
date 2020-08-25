using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit_1 : PlayerHit {

    private void OnTriggerEnter2D(Collider2D collider) {
        base.on_triggered(collider, ref PlayerData.secrets.level_1.stars_earned);
    }
}
