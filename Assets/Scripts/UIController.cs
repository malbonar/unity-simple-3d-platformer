using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public static UIController Instance { get; private set; }
    
    private void Awake() 
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        UpdateLivesText(PlayerHealth.Instance.Lives);
        UpdateScoreText(PlayerScore.Instance.GetScore);
        PlayerHealth.Instance.OnLostLife += OnLostLife;
        PlayerScore.Instance.OnScoreUpdate += OnScoreUpdate;
    }

    private void UpdateLivesText(int lives) 
    {
        livesText.text = "Lives: " + lives;
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    private void OnLostLife(object sender, int lives)
    {
        UpdateLivesText(lives);
    }

    private void OnScoreUpdate(object sender, int score)
    {
        UpdateScoreText(score);
    }
}
