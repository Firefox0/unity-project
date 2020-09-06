using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IO {

    private static string file_name = "GameData.json";
    // path that works on every OS (in Appdata/LocalLow/DefaultCompany on Windows)
    private static string path = Application.persistentDataPath + '/' + file_name;

    public static void save_json() {
        // convert native object to json
        string serialized = JsonConvert.SerializeObject(PlayerData.secrets);
        System.IO.File.WriteAllText(path, serialized);
    }

    public static void load_json() {
        if (!File.Exists(path)) {
            save_json();
            return;
        }
        string read_json = System.IO.File.ReadAllText(path);
        // convert json to native object
        Secrets deserialized =  JsonConvert.DeserializeObject<Secrets>(read_json);
        // overwrite current gamedata
        PlayerData.secrets = deserialized;
    }
}