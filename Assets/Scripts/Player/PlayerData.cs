using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {
    public static int scene_index = 0;
    public static Secrets secrets = new Secrets();
}

public class Secrets {
    public float health = 100f;
    public float stamina = 100f;
    public float walking_speed = 5f;
    public float running_speed = 7.5f;
    public int health_level = 0;
    public int stamina_level = 0;
    public int walking_speed_level = 0;
    public int running_speed_level = 0;
    public float money = 100000000;
    public int level = 0;
    public int experience = 0;
    public Level[] levels = new Level[9];

    public Secrets() {
        this.levels[0] = new Level(true);
        for (int i = 1; i < this.levels.Length; i++) {
            this.levels[i] = new Level();
        }
    }
}

public class Level {
    public bool unlocked;
    public int stars_earned;
    public bool extra_crown;
    public int record;

    public Level(bool unlocked_ = false, int stars_earned_ = 0, bool extra_crown_ = false, int record_ = 0) {
        this.unlocked = unlocked_;
        this.stars_earned = stars_earned_;
        this.extra_crown = extra_crown_;
        this.record = record_;
    }
}