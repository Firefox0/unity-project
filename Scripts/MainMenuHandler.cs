using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour {

    public GameObject main_menu;
    public Button play_button;
    public Button options_button;
    public Button quit_button;

    public GameObject options_menu;
    public Button back_button;

    void Start() {
        // scene index from build settings
        this.play_button.onClick.AddListener(() => SceneManager.LoadScene(1));
        this.options_button.onClick.AddListener(() => {
            main_menu.SetActive(false);
            options_menu.SetActive(true);
        });
        this.quit_button.onClick.AddListener(() => Application.Quit());
        this.back_button.onClick.AddListener(() => {
            main_menu.SetActive(true);
            options_menu.SetActive(false);
        });
    }
}
