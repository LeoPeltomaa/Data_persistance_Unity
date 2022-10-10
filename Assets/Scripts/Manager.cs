using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public string userName;
    public int bestScore;
    public string bestPlayer;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string BestPlayer;
        public int BestScore;
    }
    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.BestPlayer = bestPlayer;
        data.BestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json", json;
        if (File.Exists(path))
        {
            string jsoN = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsoN);
            bestPlayer = data.BestPlayer;
            bestScore = data.BestScore;
        }
    }
}
