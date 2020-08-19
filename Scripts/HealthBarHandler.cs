using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour {
    public Slider slider;
    public int health;
    void Start() {
        this.health = PlayerMain.health;
        this.slider.maxValue = this.health;
        this.slider.value = this.health;
    }

    void Update() {
        if (PlayerMain.health != this.health) {
            this.health = PlayerMain.health;
            this.slider.value = this.health;
        }    
    }
}
