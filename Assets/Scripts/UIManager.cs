using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    
    void Start()
    {
        bestScoreText.text = $"Best Score: {MainDataManager.instance.bestPlayer}: {MainDataManager.instance.bestScore.ToString()}";
    }
}
