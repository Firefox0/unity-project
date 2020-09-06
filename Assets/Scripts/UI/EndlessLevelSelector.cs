using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndlessLevelSelector : LevelSelector {
    void Start() {
        PlayerData.endless = true;

        for (int i = 0; i < this.levels.Length; i++) {
            this.level_texts[i].text = PlayerData.secrets.levels[i].record.ToString();
        }
    }
}