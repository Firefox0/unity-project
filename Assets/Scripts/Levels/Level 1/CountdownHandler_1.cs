using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownHandler_1 : CountdownHandler {
    void Awake() {
        base.set_level(ref PlayerData.secrets.level_1.stars_earned);
    }
}
