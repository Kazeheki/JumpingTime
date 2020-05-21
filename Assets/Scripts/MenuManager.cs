using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixerSnapshot m_Standard = null;

    [SerializeField]
    private AudioMixerSnapshot m_Muted = null;

    [SerializeField]
    private AudioMixerSnapshot m_MusicMuted = null;

    private float m_AudioTransitionTime = 1f;

    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        GameEvents.Restart();
    }

    public void Resume()
    {
        GameEvents.ResumeGame();
    }

    public void ToggleMuteAll(bool value)
    {
        if (value)
        {
            m_Muted.TransitionTo(m_AudioTransitionTime);
        }
        else
        {
            m_Standard.TransitionTo(m_AudioTransitionTime);
        }
    }

    public void ToggleMuteMusic(bool value)
    {
        if (value)
        {
            m_MusicMuted.TransitionTo(m_AudioTransitionTime);
        }
        else
        {
            m_Standard.TransitionTo(m_AudioTransitionTime);
        }
    }
}