using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorHandler : MonoBehaviour {

    public Button[] levels;
    public Text[] level_texts;
    public Button back_button;
    public int non_levels = 5; 

    void Start() {
        IO.load_json();
        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.LEVEL_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.LEVEL_2));
        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MAINMENU));
        for (int i = 0; i < levels.Length; i++) {
            if (PlayerData.secrets.levels[i].stars_earned > 0) {
                this.level_texts[i].text += string.Concat(Enumerable.Repeat('*', PlayerData.secrets.levels[i].stars_earned));
            }
        }
    }

    void load_scene(int scene_index) {
        PlayerData.scene_index = scene_index;
        int index = scene_index - this.non_levels;
        PlayerHit.current_level = index;
        CountdownHandler.current_level = index;
        SceneManager.LoadScene(scene_index);
    }
}
