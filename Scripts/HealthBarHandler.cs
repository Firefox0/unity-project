using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour {
    public Slider slider;
    public int health;
    void Start() {
        this.health = PlayerMain.health;
        slider.maxValue = this.health;
        slider.value = this.health;
    }

    void Update() {
        if (PlayerMain.health != this.health) {
            this.health = PlayerMain.health;
            slider.value = this.health;
        }    
    }
}
