using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopScene : MonoBehaviour {

    public Button back_button;
    
    public Button health_button;
    public Button stamina_button;
    public Button walking_button;
    public Button running_button;

    public TextMeshProUGUI health_text;
    public TextMeshProUGUI stamina_text;
    public TextMeshProUGUI walking_text;
    public TextMeshProUGUI running_text;
    public TextMeshProUGUI money_text;

    void Start() {
        this.health_button.onClick.AddListener(() => this.buy(ref health_text, ref PlayerData.secrets.health, ref PlayerData.secrets.health_level, 5));
        this.stamina_button.onClick.AddListener(() => this.buy(ref stamina_text, ref PlayerData.secrets.stamina, ref PlayerData.secrets.stamina_level, 5));
        this.walking_button.onClick.AddListener(() => this.buy(ref walking_text, ref PlayerData.secrets.walking_speed, ref PlayerData.secrets.walking_speed_level, 0.1f));
        this.running_button.onClick.AddListener(() => this.buy(ref running_text, ref PlayerData.secrets.running_speed, ref PlayerData.secrets.running_speed_level, 0.1f));
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene(PlayerData.scene_index));

        health_text.text = PlayerData.secrets.health.ToString();
        stamina_text.text = PlayerData.secrets.stamina.ToString();
        walking_text.text = PlayerData.secrets.walking_speed.ToString();
        running_text.text = PlayerData.secrets.running_speed.ToString();
        money_text.text = PlayerData.secrets.currency.ToString();
    }

    void buy(ref TextMeshProUGUI text_gui, ref float stat, ref int level, float upgrade) {
        if (PlayerData.secrets.currency < 1) {
            return;
        }

        PlayerData.secrets.currency -= 1;
        money_text.text = PlayerData.secrets.currency.ToString();
        level++;

        float new_stat = (float)Math.Round(stat + upgrade, 1);
        stat = new_stat;
        text_gui.text = new_stat.ToString();

        IO.save_json();
    }
}
