using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessLevelSelector : LevelSelector {
    void Start() {
        offset = 19;
        PlayerHit.endless = true;
        IO.load_json();

        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_FOREST_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_FOREST_2));
        levels[2].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_FOREST_3));
        levels[3].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_GAMEBOY_1));
        levels[4].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_GAMEBOY_2));
        levels[5].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_GAMEBOY_3));
        levels[6].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_CASTLE_1));
        levels[7].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_CASTLE_2));
        levels[8].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_CASTLE_3));
        levels[9].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_TOWN_1));
        levels[10].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_TOWN_2));
        levels[11].onClick.AddListener(() => this.load_scene((int)Scenes.ENDLESS_TOWN_3));
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