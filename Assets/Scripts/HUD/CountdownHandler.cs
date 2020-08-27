using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownHandler : MonoBehaviour {

    private Text countdown;
    private Text star_display;

    float current_time = 0f;
    float[] star_requirements = { 3, 5, 10 };
    public static int star_counter;
    public static int current_level;

    void Start() {
        this.countdown = this.gameObject.GetComponent<Text>();
        // get child
        this.star_display = this.gameObject.transform.Find("StarDisplay").GetComponent<Text>();
        // reset static star counter
        star_counter = 0;
        this.current_time = this.star_requirements[0];
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
            PlayerData.secrets.levels[current_level].stars_earned = star_counter;
            IO.save_json();
            SceneManager.LoadScene((int)Scenes.LEVELSELECTION);
            return;
        }
        this.current_time = this.star_requirements[star_counter];
    }
}
