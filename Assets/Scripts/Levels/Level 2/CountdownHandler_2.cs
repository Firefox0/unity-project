using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownHandler_2 : CountdownHandler {
    void Awake() {
        base.set_level(ref PlayerData.secrets.level_2.stars_earned);
    }
}
