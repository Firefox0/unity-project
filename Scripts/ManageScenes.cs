using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour {
    void Update() {
        if(PlayerMain.health <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // set manually to 1 so loading scene doesn't get called infinitely
            PlayerMain.health = 1;
        }
    }
}
