using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Debuff : MonoBehaviour {

    public float debuff_time;

    protected bool has_ended() {
        // check if debuff time is over
        this.debuff_time -= Time.deltaTime;
        return this.debuff_time <= 0 ? true : false;
    }
}
