using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneHandler : MonoBehaviour {

    public Button retry_button;
    public Button shop_button;
    public Button back_button;

    void Start() {
        this.retry_button.onClick.AddListener(() => SceneManager.LoadScene(PlayerMain.scene_index));
        this.shop_button.onClick.AddListener(() => SceneManager.LoadScene(3));
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene(1));
    }
}
