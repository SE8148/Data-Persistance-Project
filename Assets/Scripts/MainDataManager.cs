using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainDataManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private MainManager mainManager;

    public static MainDataManager instance;
    public int bestScore;
    public string bestPlayer;
    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        mainManager = FindObjectOfType<MainManager>();

        LoadData();
    }

    private void StorePlayerName()
    {
        playerName = playerNameText.text;
    }

    public void LoadGame()
    {
        StorePlayerName();
        SceneManager.LoadScene("main");
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.name = bestPlayer;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.game", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.game";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestPlayer = data.name;
            bestScore = data.score;
        }
    }
}
