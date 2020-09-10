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
    public Button slow_button;
    public Button stun_button; 

    public TextMeshProUGUI health_text;
    public TextMeshProUGUI stamina_text;
    public TextMeshProUGUI walking_text;
    public TextMeshProUGUI running_text;
    public TextMeshProUGUI slow_text;
    public TextMeshProUGUI stun_text;
    public TextMeshProUGUI money_text;

    public TextMeshProUGUI error;

    void Start() {
        this.health_button.onClick.AddListener(() => this.buy(ref health_text, ref PlayerData.secrets.health, 5, 1000));
        this.stamina_button.onClick.AddListener(() => this.buy(ref stamina_text, ref PlayerData.secrets.stamina, 5, 1000));
        this.walking_button.onClick.AddListener(() => this.buy(ref walking_text, ref PlayerData.secrets.walking_speed, 0.1f, 10));
        this.running_button.onClick.AddListener(() => this.buy(ref running_text, ref PlayerData.secrets.running_speed, 0.1f, 12.5f));
        this.slow_button.onClick.AddListener(() => this.buy(ref slow_text, ref PlayerData.secrets.slow_resistance, 0.5f, 100));
        this.stun_button.onClick.AddListener(() => this.buy(ref stun_text, ref PlayerData.secrets.stun_resistance, 0.5f, 100));
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene(PlayerData.scene_index));

        health_text.text = PlayerData.secrets.health.ToString();
        stamina_text.text = PlayerData.secrets.stamina.ToString();
        walking_text.text = PlayerData.secrets.walking_speed.ToString();
        running_text.text = PlayerData.secrets.running_speed.ToString();
        slow_text.text = PlayerData.secrets.slow_resistance.ToString();
        stun_text.text = PlayerData.secrets.stun_resistance.ToString();
        money_text.text = PlayerData.secrets.currency.ToString();
    }

    void buy(ref TextMeshProUGUI text_gui, ref float stat, float upgrade, float maximum) {
        if (PlayerData.secrets.currency <= 0) {
            error.text = "You don't have enough money to buy this.";
            return;
        }
        else if (stat == maximum) {
            error.text = "You can't buy this. The Maximum was reached.";
            return;
        }
        else {
            error.text = "";
        }

        PlayerData.secrets.currency -= 1;
        money_text.text = PlayerData.secrets.currency.ToString();

        float new_stat = (float)Math.Round(stat + upgrade, 1);
        stat = new_stat;
        text_gui.text = new_stat.ToString();

        IO.save_json();
    }
}
