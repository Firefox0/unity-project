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
    public Button level_2;
    public Text level_2_text;
    public Button back_button;

    void Start() {
        IO.load_json();
        if (PlayerData.secrets.level_1.stars_earned > 0) {
            this.level_1_text.text += string.Concat(Enumerable.Repeat('*', PlayerData.secrets.level_1.stars_earned));
        } 
        level_1.onClick.AddListener(() => load_scene((int)Scenes.LEVEL_1));
        if (PlayerData.secrets.level_2.stars_earned > 0) {
            this.level_2_text.text += string.Concat(Enumerable.Repeat('*', PlayerData.secrets.level_2.stars_earned));
        }
        level_2.onClick.AddListener(() => load_scene((int)Scenes.LEVEL_2));
        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MAINMENU));
    }

    void load_scene(int scene_index) {
        PlayerData.scene_index = scene_index;
        SceneManager.LoadScene(scene_index);
    }
}
