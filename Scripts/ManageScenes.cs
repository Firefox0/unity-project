using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour {
    void Update() {
        if(PlayerMain.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerMain.health = PlayerMain.max_health;
            PlayerMovement.stamina = PlayerMovement.max_stamina;
        }
    }
}
