using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsSceneHandler : MonoBehaviour {

    public Button back_button;

    void Start() {
        this.back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MAINMENU));
    }
}
