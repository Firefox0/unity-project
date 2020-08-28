using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public static float health;
    public static int current_level;
    public static bool endless;

    void Awake() {
        health = PlayerData.secrets.health;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            // increase damage depending on stage
            float amplifier = 1 + PlayerData.secrets.stage * 0.5f;
            health -= collider.gameObject.GetComponent<Basic_Projectile>().damage * amplifier;
            if (health <= 0) {
                if (endless) {
                    PlayerData.secrets.levels[current_level].record = Timer.current_time;
                }
                else {
                    // reference for readability
                    ref int current_stars = ref PlayerData.secrets.levels[current_level].stars_earned;
                    // save when you beat previous score
                    if (CountdownHandler.star_counter > current_stars) {
                        // add stars to currency
                        PlayerData.secrets.currency += CountdownHandler.star_counter - current_stars;
                        // save progression
                        current_stars = CountdownHandler.star_counter;
                    }
                }
                IO.save_json();
                SceneManager.LoadScene((int)Scenes.DEATH);
            }
        }
    }
}
