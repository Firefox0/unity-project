using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour {

    public Button play_button;
    public Button options_button;
    public Button quit_button;

    void Start() {
        // scene index from build settings
        this.play_button.onClick.AddListener(() => SceneManager.LoadScene(1));
        this.options_button.onClick.AddListener(() => SceneManager.LoadScene(2));
        this.quit_button.onClick.AddListener(() => Application.Quit());
    }
}
