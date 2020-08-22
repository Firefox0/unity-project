using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorHandler : MonoBehaviour {

    public Button level_1;
    public Text level_1_text;
    public Button back_button;

    void Start() {
        IO.load_json();
        if (PlayerData.secrets.level_1.stars_earned > 0) {
            this.level_1_text.text += string.Concat(Enumerable.Repeat('*', PlayerData.secrets.level_1.stars_earned));
        } 
        level_1.onClick.AddListener(() => {
            PlayerData.scene_index = Scenes.TESTLEVEL;
            SceneManager.LoadScene(Scenes.TESTLEVEL);
        });
        back_button.onClick.AddListener(() => SceneManager.LoadScene(Scenes.MAINMENU));
    }
}
