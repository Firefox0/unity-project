using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopSceneHandler : MonoBehaviour {

    public Button back_button;
    
    public Button health_button;
    public Button stamina_button;
    public Button walking_button;
    public Button running_button;

    public GameObject health_object;
    public GameObject stamina_object;
    public GameObject walking_object;
    public GameObject running_object;
    public GameObject money_object; 

    private TextMeshProUGUI health_text;
    private TextMeshProUGUI stamina_text;
    private TextMeshProUGUI walking_text;
    private TextMeshProUGUI running_text;
    private TextMeshProUGUI money_text;

    private float money;

    void Start() {
        this.health_button.onClick.AddListener(() => this.buy(ref health_text, ref PlayerData.secrets.health, ref PlayerData.secrets.health_level, 5));
        this.stamina_button.onClick.AddListener(() => this.buy(ref stamina_text, ref PlayerData.secrets.stamina, ref PlayerData.secrets.stamina_level, 5));
        this.walking_button.onClick.AddListener(() => this.buy(ref walking_text, ref PlayerData.secrets.walking_speed, ref PlayerData.secrets.walking_speed_level, 0.1f));
        this.running_button.onClick.AddListener(() => this.buy(ref running_text, ref PlayerData.secrets.running_speed, ref PlayerData.secrets.running_speed_level, 0.1f));
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.DEATH));

        money = PlayerData.secrets.money;

        health_text = health_object.GetComponent<TextMeshProUGUI>();
        stamina_text = stamina_object.GetComponent<TextMeshProUGUI>();
        walking_text = walking_object.GetComponent<TextMeshProUGUI>();
        running_text = running_object.GetComponent<TextMeshProUGUI>();
        money_text = money_object.GetComponent<TextMeshProUGUI>();

        health_text.text = PlayerData.secrets.health.ToString();
        stamina_text.text = PlayerData.secrets.stamina.ToString();
        walking_text.text = PlayerData.secrets.walking_speed.ToString();
        running_text.text = PlayerData.secrets.running_speed.ToString();
        money_text.text = money.ToString();
    }

    void buy(ref TextMeshProUGUI text_gui, ref float stat, ref int level, float upgrade) {
        float price = 100 + level * 50;
        if (PlayerData.secrets.money < price) {
            return;
        }

        PlayerData.secrets.money -= price;
        money_text.text = PlayerData.secrets.money.ToString();
        level++;

        float new_stat = (float)Math.Round(stat + upgrade, 1);
        stat = new_stat;
        text_gui.text = new_stat.ToString();

        IO.save_json();
    }
}
