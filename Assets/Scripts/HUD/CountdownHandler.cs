﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownHandler : MonoBehaviour {

    public Text countdown;
    public Text star_display;

    float current_time = 0f;
    float[] star_requirements = { 1, 3, 5 };
    int star_counter = 0;

    void Start() {
        this.current_time = this.star_requirements[star_counter];
    }

    void Update() {
        current_time -= Time.deltaTime;
        if (current_time <= 0) {
            this.update_stars();
            this.next_requirement();
        }
        else {
            countdown.text = current_time.ToString();
        }
    }

    void update_stars() {
        this.star_counter++;
        this.star_display.text += '*';
    }

    void next_requirement() {
        if (this.star_counter == this.star_requirements.Length) {
            SceneManager.LoadScene(1);
            return;
        }
        this.current_time = this.star_requirements[star_counter];
    }
}