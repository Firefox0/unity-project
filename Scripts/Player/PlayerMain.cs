using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    public GameObject player_main;

    public static int scene_index = 0;
    public static int gold = 0;

    void Start() {
        DontDestroyOnLoad(player_main);
    }
}
