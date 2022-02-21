using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainDataManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;

    public static MainDataManager instance;
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
}
