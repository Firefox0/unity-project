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

    protected void on_trigger(Collider2D collider, ref int current_level) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            float damage = collider.gameObject.GetComponent<Properties>().damage;
            health -= damage;
            if (health <= 0) {
                if (CountdownHandler.star_counter > current_level) {
                    current_level = CountdownHandler.star_counter;
                    IO.save_json();
                }
                SceneManager.LoadScene((int)Scenes.DEATH);
            }
        }
    }
}
