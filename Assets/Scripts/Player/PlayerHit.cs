using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public static float health;
    public static int current_level;

    void Awake() {
        health = PlayerData.secrets.health;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") { 
            Destroy(collider.gameObject);
            health -= collider.gameObject.GetComponent<Basic_Projectile>().damage;
            if (health <= 0) {
                ref int current_stars = ref PlayerData.secrets.levels[current_level].stars_earned;
                // save when you beat previous score
                if (CountdownHandler.star_counter > current_stars) {
                    current_stars = CountdownHandler.star_counter;
                    IO.save_json();
                }
                SceneManager.LoadScene((int)Scenes.DEATH);
            }
        }
    }
}
