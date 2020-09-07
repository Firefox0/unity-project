using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Debuff : Movement_Debuff {

    private void Awake() {
        base.resistance = PlayerData.secrets.slow_resistance;
        base.slow_factor = base.resistance >= base.slow_percentage ? 1 : 1 - (base.slow_percentage - base.resistance) / 100;
    }
}
