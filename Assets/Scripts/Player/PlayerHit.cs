using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public GameObject player;

    public static float health;

    void Awake() {
        health = PlayerData.secrets.health;    
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            health -= 20;
            if (health <= 0) {
                if (CountdownHandler.star_counter > PlayerData.secrets.level_1.stars_earned) {
                    PlayerData.secrets.level_1.stars_earned = CountdownHandler.star_counter;
                    IO.save_json();
                }
                SceneManager.LoadScene(Scenes.DEATH);
            }
        }
    }
}
