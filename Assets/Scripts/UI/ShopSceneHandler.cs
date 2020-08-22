using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopSceneHandler : MonoBehaviour {

    public Button back_button;
    
    /* 
    public Button health_button;
    public Button stamina_button;
    public Button walking_button;
    public Button running_button;

    public GameObject health;
    public GameObject stamina;
    public GameObject walking;
    public GameObject running;

    private TextMeshProUGUI health_text;
    private TextMeshProUGUI stamina_text;
    private TextMeshProUGUI walking_text;
    private TextMeshProUGUI running_text;

    private float money;

    */
    void Start() {
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene(Scenes.DEATH));
        /*
        this.health_button.onClick.AddListener()

        health_text = health.GetComponent<TextMeshProUGUI>();
        stamina_text = stamina.GetComponent<TextMeshProUGUI>();
        walking_text = walking.GetComponent<TextMeshProUGUI>();
        running_text = running.GetComponent<TextMeshProUGUI>();

        health_text.text = PlayerData.secrets.health.ToString();
        stamina_text.text = PlayerData.secrets.stamina.ToString();
        walking_text.text = PlayerData.secrets.walking_speed.ToString();
        running_text.text = PlayerData.secrets.running_speed.ToString();

        money = PlayerData.secrets.money;
        */
    }

    /*
    void buy_health(int stat, int level, int factor) {  
        float price = this.get_price(level);
        if (this.money < price) {
            return;
        }
        this.money -= price;
        float new_stat = 100 + level * factor;
        health_text.text = 100 + level *
    }

    float get_stat(int stat, int factor) {
        return stat * factor;
    }

    float get_price(int level) {
        return level * 50 + 100;
    }
    */
}
