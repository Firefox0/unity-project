using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownHandler_5 : CountdownHandler {
    void Awake() {
        base.set_level(ref PlayerData.secrets.level_5.stars_earned);
    }
}
