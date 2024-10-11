//using Palmmedia.ReportGenerator.Core;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonSettings : MonoBehaviour
{
    public class SettingsFile {

        public bool sfx;
        public bool music;
        public bool pp;
    
    }
    public SettingsFile settings;

    // Start is called before the first frame update

    public void Save(bool a, bool b, bool c) {

        SettingsFile jesonFile = new SettingsFile
        {
            sfx = a,
            music = b,
            pp = c
        };
    
        string json = JsonUtility.ToJson(jesonFile);

        File.WriteAllText(Application.dataPath + "/settings.txt", json);
    }

    public bool Load() {
        if (File.Exists(Application.dataPath + "/settings.txt")) { 
            
            string json = File.ReadAllText(Application.dataPath + "/settings.txt");
            settings = JsonUtility.FromJson<SettingsFile>(json);
            Debug.Log(json);

            return true;
        }

        return false;
    }
}
