using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandler : MonoBehaviour {
    public GameObject countdown;
    public GameObject timer;
    private GameObject instantiated_object;

    void Awake() {
        if (PlayerData.endless) {
            this.instantiated_object = Instantiate(timer, this.transform);
        }
        else {
            this.instantiated_object = Instantiate(countdown, this.transform);
        }
        this.instantiated_object.transform.parent = this.transform;
    }
}
