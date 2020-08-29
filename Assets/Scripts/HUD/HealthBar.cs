using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour {
    public Slider slider;
    public float health;

    void Start() {
        this.health = PlayerHit.health;
        this.slider.maxValue = this.health;
        this.slider.value = this.health;
    }

    void Update() {
        if (PlayerHit.health != this.health) {
            this.health = PlayerHit.health;
            this.slider.value = this.health;
        }    
    }
}
