using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {
    public Button[] levels;
    public Text[] level_texts;
    public Button back_button;
    public int offset = 7;

    void Awake() {
        IO.load_json();
        levels[0].onClick.AddListener(() => this.load_scene((int)Scenes.MOUNTAIN_1));
        levels[1].onClick.AddListener(() => this.load_scene((int)Scenes.MOUNTAIN_2));
        levels[2].onClick.AddListener(() => this.load_scene((int)Scenes.MOUNTAIN_3));
        levels[3].onClick.AddListener(() => this.load_scene((int)Scenes.GAMEBOY_1));
        levels[4].onClick.AddListener(() => this.load_scene((int)Scenes.GAMEBOY_2));
        levels[5].onClick.AddListener(() => this.load_scene((int)Scenes.GAMEBOY_3));
        levels[6].onClick.AddListener(() => this.load_scene((int)Scenes.CASTLE_1));
        levels[7].onClick.AddListener(() => this.load_scene((int)Scenes.CASTLE_2));
        levels[8].onClick.AddListener(() => this.load_scene((int)Scenes.CASTLE_3));
        levels[9].onClick.AddListener(() => this.load_scene((int)Scenes.CASTLE_4));
        levels[10].onClick.AddListener(() => this.load_scene((int)Scenes.FOREST_1));
        levels[11].onClick.AddListener(() => this.load_scene((int)Scenes.FOREST_2));
        levels[12].onClick.AddListener(() => this.load_scene((int)Scenes.FOREST_3));

        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MODESELECTION));
    }

    private void load_scene(int scene_index) {
        PlayerData.scene_index = scene_index;
        int index = scene_index - this.offset;
        PlayerHit.current_level = index;
        if (!PlayerData.endless) {
            Countdown.current_level = index;
        }
        SceneManager.LoadScene(scene_index);
    }
}
