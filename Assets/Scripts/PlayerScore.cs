using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private int LostLifePenalty;
    public EventHandler<int> OnScoreUpdate;
    private int _score = 0;
    public static PlayerScore Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        PlayerHealth.Instance.OnLostLife += OnLostLife;
    }

    public void AdjustScore(int amount) 
    {
        _score += amount;
        if (OnScoreUpdate != null)
        {
            OnScoreUpdate(this, _score);
        }
    }

    private void OnLostLife(object sender, int _)
    {
        AdjustScore(Math.Abs(LostLifePenalty) * -1);
    }

    public int GetScore => _score;
}
