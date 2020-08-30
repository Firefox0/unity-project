using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Button play_button;
    public Button options_button;
    public Button quit_button;

    void Start() {
        // scene index from build settings
        this.play_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MODESELECTION));
        this.options_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.OPTIONS));
        this.quit_button.onClick.AddListener(() => Application.Quit());
    }
}