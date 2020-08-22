using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {
    public static int scene_index = 0;
    public static Secrets secrets = new Secrets();
}

public class Secrets {
    public int money;
    public int level;
    public int experience;
    public Level level_1;
    public Level level_2;
    public Level level_3;
    public Level level_4;
    public Level level_5;
    public Level level_6;
    public Level level_7;
    public Level level_8;
    public Level level_9;

    public Secrets() {
        this.money = 0;
        this.level = 0;
        this.experience = 0;
        this.level_1 = new Level(true);
        this.level_2 = new Level();
        this.level_3 = new Level();
        this.level_4 = new Level();
        this.level_5 = new Level();
        this.level_6 = new Level();
        this.level_7 = new Level();
        this.level_8 = new Level();
        this.level_9 = new Level();
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