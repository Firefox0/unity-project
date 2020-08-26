using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerHit_5 : PlayerHit {

    private void OnTriggerEnter2D(Collider2D collider) {
        base.on_triggered(collider, ref PlayerData.secrets.level_5.stars_earned);
    }
}
