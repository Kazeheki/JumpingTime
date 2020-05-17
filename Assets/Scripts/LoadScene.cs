using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string m_SceneName;

    private void Start()
    {
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Additive);
    }
}