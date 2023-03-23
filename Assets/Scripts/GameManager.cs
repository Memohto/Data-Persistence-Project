using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string Name { get; set; }
    public int BestScore { get; set; }

    private void Awake()
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData() {
        GameData data = new GameData(Name, BestScore);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/gameData.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            Name = data.Name;
            BestScore = data.BestScore;
        }
    }

    [System.Serializable]
    class GameData {
        public string Name;
        public int BestScore;

        public GameData(string Name, int BestScore) {
            this.Name = Name;
            this.BestScore = BestScore;
        }
    }
}
