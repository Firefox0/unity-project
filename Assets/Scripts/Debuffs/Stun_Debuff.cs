using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_Debuff : Movement_Debuff {
    private void Awake() {
        base.debuff_time *= (PlayerData.secrets.stun_resistance / 100);
    }
}
