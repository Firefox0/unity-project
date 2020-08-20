using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour {

    public GameObject player;

    public static int max_health = 100;
    public static int health = 100;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Projectile") {
            Destroy(collider.gameObject);
            health -= 20;
            if (health <= 0) {
                SceneManager.LoadScene(4);
                health = max_health;
                PlayerMovement.stamina = PlayerMovement.max_stamina;
            }
        }
    }
}
