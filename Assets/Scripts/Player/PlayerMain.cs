using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour {

    // Class which doesn't get destroyed despite scene reload/changes,
    // important so we can remember things like gold or current level

    public GameObject player_main;

    public static int scene_index = 0;
    public static int gold = 0;

    void Start() {
        DontDestroyOnLoad(player_main);
    }
}
