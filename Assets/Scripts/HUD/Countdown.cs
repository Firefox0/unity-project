using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    private Text countdown;
    private Text star_display;

    float current_time = 0f;
    float[] star_requirements = { 15, 20, 25 };
    public static int star_counter;
    public static int current_level;

    void Awake() {
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
            // add stars to currency
            PlayerData.secrets.currency += star_counter - PlayerData.secrets.levels[current_level].stars_earned;
            // check last level
            if (current_level == PlayerData.secrets.levels.Length - 1) {
                PlayerData.secrets.stage++;
                for (int i = 0; i < PlayerData.secrets.levels.Length; i++) {
                    PlayerData.secrets.levels[i].stars_earned = 0;
                }
            }
            else {
                // save progression
                PlayerData.secrets.levels[current_level].stars_earned = star_counter;
            }
            IO.save_json();
            SceneManager.LoadScene((int)Scenes.NORMALLEVELSELECTION);
        }
        else {
            this.current_time = this.star_requirements[star_counter];
        }
    }
}
