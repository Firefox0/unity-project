﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelectionHandler : MonoBehaviour {
    public Button shop;
    public Button normal;
    public Button endless;
    public Button back_button;

    void Start() {
        shop.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.SHOP));
        normal.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.NORMALLEVELSELECTION));
        endless.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.ENDLESSLEVELSELECTION));
        back_button.onClick.AddListener(() => SceneManager.LoadScene((int)Scenes.MAINMENU));
    }
}