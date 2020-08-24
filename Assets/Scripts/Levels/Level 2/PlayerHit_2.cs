using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerHit_2 : PlayerHit {
    private void OnTriggerEnter2D(Collider2D collider) {
        base.on_trigger(collider, ref PlayerData.secrets.level_2.stars_earned);
    }
}
