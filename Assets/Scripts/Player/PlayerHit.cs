using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public static float health;
    public static int current_level;
    // normal or endless mode
    public static bool endless;
    private float amplifier;
    public GameObject damaged;

    private void Awake() {
        health = PlayerData.secrets.health;
        this.amplifier = 1 + PlayerData.secrets.stage * 0.5f;
    }

    private void damage_player(Collider2D collider) {
        // increase damage based on stage to increase difficulty
        health -= collider.gameObject.GetComponent<Basic_Projectile>().damage * amplifier;
    }

    private void update_record() {
        // save time from endless mode
        if (Timer.current_time > PlayerData.secrets.levels[current_level].record) {
            PlayerData.secrets.levels[current_level].record = Timer.current_time;
        }
    }

    private void update_stars() {
        // reference for readability
        ref int current_stars = ref PlayerData.secrets.levels[current_level].stars_earned;
        // save when you beat previous score
        if (Countdown.star_counter > current_stars) {
            // add stars to currency
            PlayerData.secrets.currency += Countdown.star_counter - current_stars;
            // save progression
            current_stars = Countdown.star_counter;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            this.damage_player(collider);
            if (health <= 0) {
                if (PlayerData.endless) {
                    this.update_record();
                }
                else {
                    this.update_stars();
                }
                IO.save_json();
                SceneManager.LoadScene((int)Scenes.DEATH);
            }
        }
    }
}