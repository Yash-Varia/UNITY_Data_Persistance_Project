using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class PlayerInfoScript : MonoBehaviour
{
    public static PlayerInfoScript instance;

    public string currentPlayerName;
    public string name;
    public float score;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadData();        
    }

    public class Data
    {
        public string name = PlayerInfoScript.instance.name;
        public float score = PlayerInfoScript.instance.score;
    }

    public void SaveData()
    {   
        Data data = new Data();
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            PlayerInfoScript.instance.name = data.name;
            PlayerInfoScript.instance.score = data.score;
        }
    }
}
