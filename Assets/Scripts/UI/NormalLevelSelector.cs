using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalLevelSelector : LevelSelector {
    public Image[] locks;
    public TextMeshProUGUI stage_text;

    void Start() {
        offset = 7;
        PlayerHit.endless = false;
        IO.load_json();
        stage_text.text = PlayerData.secrets.stage.ToString();
        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_FOREST_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_FOREST_2));
        levels[2].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_FOREST_3));
        levels[3].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_GAMEBOY_1));
        levels[4].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_GAMEBOY_2));
        levels[5].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_GAMEBOY_3));
        levels[6].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_CASTLE_1));
        levels[7].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_CASTLE_2));
        levels[8].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_CASTLE_3));
        levels[9].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_TOWN_1));
        levels[10].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_TOWN_2));
        levels[11].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_TOWN_3));
        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MODESELECTION));
        for (int i = 0; i < levels.Length; i++) {
            if (PlayerData.secrets.levels[i].stars_earned > 0) {
                this.level_texts[i].text += string.Concat(Enumerable.Repeat('*', PlayerData.secrets.levels[i].stars_earned));
                if (i < locks.Length) {
                    if (PlayerData.secrets.levels[i].stars_earned == 3) {
                        locks[i].enabled = false;
                        levels[i + 1].interactable = true;
                    }
                }
            }
        }
    }

    void load_scene(int scene_index) {
        PlayerData.scene_index = scene_index;
        int index = scene_index - this.offset;
        PlayerHit.current_level = index;
        Countdown.current_level = index;
        SceneManager.LoadScene(scene_index);
    }
}