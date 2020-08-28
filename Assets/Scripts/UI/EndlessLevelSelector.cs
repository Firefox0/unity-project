using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessLevelSelector : LevelSelectorHandler {
    void Start() {
        offset = 11;
        PlayerHit.endless = true;
        IO.load_json();

        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_LEVEL_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_LEVEL_2));
        levels[2].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_LEVEL_3));
        levels[3].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_LEVEL_4));
        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MODESELECTION));
        for (int i = 0; i < this.levels.Length; i++) {
            this.level_texts[i].text = PlayerData.secrets.levels[i].record.ToString();
        }
    }

    void load_scene(int scene_index) {
        PlayerData.scene_index = scene_index;
        PlayerHit.current_level = scene_index - this.offset;
        SceneManager.LoadScene(scene_index);
    }
}