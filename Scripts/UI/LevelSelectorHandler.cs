using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorHandler : MonoBehaviour {

    public Button level_1;
    public Button back_button;

    void Start() {
        level_1.onClick.AddListener(() => {
            PlayerMain.scene_index = 5;
            SceneManager.LoadScene(5);
        });
        back_button.onClick.AddListener(() => SceneManager.LoadScene(0));
    }
}
