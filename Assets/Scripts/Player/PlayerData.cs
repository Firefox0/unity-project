﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {
    public static int scene_index = 0;
    public static bool endless = false;
    public static Secrets secrets = new Secrets();
}

public class Secrets {
    public float health = 100;
    public float stamina = 100;
    public float walking_speed = 5f;
    public float running_speed = 7.5f;
    public float slow_resistance = 0;
    public float stun_resistance = 0;
    public int currency = 0;
    public int stage = 0;
    public Level[] levels = new Level[13];
    
    public Secrets() {
        for (int i = 0; i < this.levels.Length; i++) {
            this.levels[i] = new Level();
        }
    }
}

public class Level {
    public int stars_earned = 0;
    public float record = 0;
}