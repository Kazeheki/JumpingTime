using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action OnDeadlyHit;

    public static void HitDeadly()
    {
        OnDeadlyHit?.Invoke();
    }

    public static event Action<int> OnHit;

    public static void Hit(int damage)
    {
        OnHit?.Invoke(damage);
    }

    public static event Action<int, int> OnHealthChanged;

    public static void HealthChange(int currentHealth, int maxHealth)
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    public static event Action OnRestart;

    public static void Restart()
    {
        OnRestart?.Invoke();
    }

    public static event Action OnGameOver;

    public static void EndGame()
    {
        OnGameOver?.Invoke();
    }

    public static event Action<int> OnIncreaseHealth;

    public static void IncreaseHealth(int amount)
    {
        OnIncreaseHealth?.Invoke(amount);
    }

    public static event Action<int> OnIncreaseScore;

    public static void IncreaseScore(int amount)
    {
        OnIncreaseScore?.Invoke(amount);
    }

    public static event Action<int> OnUpdateScoreVisuals;

    public static void UpdateScoreVisuals(int currentScore)
    {
        OnUpdateScoreVisuals?.Invoke(currentScore);
    }
}