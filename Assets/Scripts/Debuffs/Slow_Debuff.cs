using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Debuff : Movement_Debuff {

    private void Awake() {
        if (PlayerData.secrets.slow_resistance >= base.slow_percentage) {
            base.slow_factor = 1;
        }
        else {
            base.slow_factor = 1 - (base.slow_percentage - PlayerData.secrets.slow_resistance) / 100;
        }
    }
}
