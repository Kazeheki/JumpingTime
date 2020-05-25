using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string m_PauseMenuSceneName = "PauseMenu";

    [SerializeField]
    private string m_GameOverSceneName = "GameOverMenu";

    private static bool m_GameOver;

    private void OnEnable()
    {
        Time.timeScale = 0;
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.OnRestart += OnRestart;
        GameEvents.OnResume += ResumeGame;
    }

    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.OnRestart -= OnRestart;
        GameEvents.OnResume -= ResumeGame;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        m_GameOver = true;
        if (!SceneManager.GetSceneByName(m_GameOverSceneName).isLoaded)
        {
            SceneManager.LoadScene(m_GameOverSceneName, LoadSceneMode.Additive);
        }
    }

    private void OnRestart()
    {
        Time.timeScale = 1;
        m_GameOver = false;

        if (SceneManager.GetSceneByName(m_PauseMenuSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(m_PauseMenuSceneName);
        }

        if (SceneManager.GetSceneByName(m_GameOverSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(m_GameOverSceneName);
        }
    }

    public void RestartGame(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        Debug.Log("Triggered Restart");
        GameEvents.Restart();
    }

    public void TogglePause(InputAction.CallbackContext context)
    {
        if (IsGameOver || !context.performed)
        {
            return;
        }

        if (SceneManager.GetSceneByName(m_PauseMenuSceneName).isLoaded)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(m_PauseMenuSceneName, LoadSceneMode.Additive);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        if (SceneManager.GetSceneByName(m_PauseMenuSceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(m_PauseMenuSceneName);
        }
    }

    public static bool IsGameRunning => !m_GameOver;

    public static bool IsGameOver => m_GameOver;
}