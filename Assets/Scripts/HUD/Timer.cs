using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text timer;
    public static float current_time = 0f;
    public static int current_level;

    void Start() {
        this.timer = this.gameObject.GetComponent<Text>();
        current_time = 0f;
    }

    void Update() {
        current_time += Time.deltaTime;
        current_time = (float)System.Math.Round(current_time, 3);
        timer.text = current_time.ToString();
    }
}
