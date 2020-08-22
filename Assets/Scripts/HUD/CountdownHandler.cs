using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownHandler : MonoBehaviour {

    public Text countdown;
    public Text star_display;

    float current_time = 0f;
    float[] star_requirements = { 1, 3, 5 };
    public static int star_counter = 0;

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
        star_counter++;
        this.star_display.text += '*';
    }

    void next_requirement() {
        if (star_counter == this.star_requirements.Length) {
            PlayerData.secrets.level_1.stars_earned = star_counter;
            IO.save_json();
            SceneManager.LoadScene(Scenes.LEVELSELECTION);
            return;
        }
        this.current_time = this.star_requirements[star_counter];
    }
}
