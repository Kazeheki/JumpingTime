using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool m_GameOver;

    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.OnRestart += OnRestart;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.OnRestart -= OnRestart;
    }

    private void OnGameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
        m_GameOver = true;
    }

    private void OnRestart()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1;
        m_GameOver = false;
    }

    public void RestartGame()
    {
        Debug.Log("Triggered Restart");
        GameEvents.Restart();
    }

    public static bool IsGameRunning => !m_GameOver;

    public static bool IsGameOver => m_GameOver;
}