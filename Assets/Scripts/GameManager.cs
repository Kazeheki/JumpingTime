using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GameManager : MonoBehaviour
{
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
    }

    private void OnRestart()
    {
        Debug.Log("Restarting Game");
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        Debug.Log("Triggered Restart");
        GameEvents.Restart();
    }
}