using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public static float health;

    void Awake() {
        health = PlayerData.secrets.health;    
    }

    // reference to current level to save stars earned
    protected void on_triggered(Collider2D collider, ref int current_level) {
        if (collider.tag == "Projectile") { 
            Destroy(collider.gameObject);
            float damage = collider.gameObject.GetComponent<Basic_Projectile>().damage;
            health -= damage;
            if (health <= 0) {
                // save when you beat previous score
                if (CountdownHandler.star_counter > current_level) {
                    current_level = CountdownHandler.star_counter;
                    PlayerData.secrets.level_2.stars_earned = CountdownHandler.star_counter;
                    IO.save_json();
                }
                SceneManager.LoadScene((int)Scenes.DEATH);
            }
        }
    }
}
