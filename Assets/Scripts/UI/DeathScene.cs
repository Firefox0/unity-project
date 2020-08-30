using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour {

    public Button retry_button;
    public Button back_button;

    void Start() {
        this.retry_button.onClick.AddListener(() => SceneManager.LoadScene(PlayerData.scene_index));
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MODESELECTION));
    }
}
