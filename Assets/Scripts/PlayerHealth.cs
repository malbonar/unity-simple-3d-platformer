using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public EventHandler<int> OnLostLife;

    [SerializeField] private int lives = 1;

    public static PlayerHealth Instance { get; private set;}

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public int Lives => lives;
    
    public void LoseLife()
    {
        lives = lives - 1;
        if (OnLostLife != null)
        {
            OnLostLife(this, lives);
        }
    }

    public bool IsAlive => lives > 0;
}
