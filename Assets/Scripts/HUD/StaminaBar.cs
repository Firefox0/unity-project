using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarHandler : MonoBehaviour {
    public Slider slider;
    public float stamina;
    void Start() {
        this.stamina = PlayerMovement.stamina;
        this.slider.maxValue = this.stamina;
        this.slider.value = this.stamina;
    }

    void Update() {
        if (PlayerMovement.stamina != this.stamina) {
            this.stamina = PlayerMovement.stamina;
            this.slider.value = this.stamina;
        }
    }
}
