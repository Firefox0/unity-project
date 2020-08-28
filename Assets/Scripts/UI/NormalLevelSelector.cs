using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NormalLevelSelector : LevelSelectorHandler {
    public Image[] locks;
    public TextMeshProUGUI stage_text;

    void Start() {
        offset = 7;
        PlayerHit.endless = false;
        IO.load_json();
        stage_text.text = PlayerData.secrets.stage.ToString();

        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_LEVEL_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_LEVEL_2));
        levels[2].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_LEVEL_3));
        levels[3].onClick.AddListener(() => this.load_scene((int)Scenes.NORMAL_LEVEL_4));
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
        CountdownHandler.current_level = index;
        SceneManager.LoadScene(scene_index);
    }
}