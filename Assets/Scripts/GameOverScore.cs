using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;

    void Start()
    {
        scoreText.text = "Score: " + PlayerScore.Instance.GetScore;
        gameOverText.text = PlayerHealth.Instance.Lives > 0 ? "GAME COMPLETE" : "GAME OVER";

        var scoreController = GameObject.Find("PlayerScore");
        if (scoreController != null)
            Destroy(scoreController);
        
        var livesController = GameObject.Find("PlayerHealth");
        if (livesController != null)
            Destroy(livesController);
        
        var gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
            Destroy(gameManager);
    }
}
