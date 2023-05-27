using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private string gameOverSceneName = "GameOver";

    public static GameOverController Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    void Update()
    {
        // as this object is dont destoy on load it will be present in game over scene
        if (SceneManager.GetActiveScene().name != "GameOver")
            CheckGameOver();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }

    private void CheckGameOver() 
    {
        if (PlayerHealth.Instance.Lives == 0)
            GameOver();
    }
}
