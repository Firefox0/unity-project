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
        PlayerData.endless = false;
        stage_text.text = PlayerData.secrets.stage.ToString();

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
}