using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string m_SceneName = "Scene name here";

    private void Start()
    {
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Additive);
    }
}