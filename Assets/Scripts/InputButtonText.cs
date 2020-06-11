using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InputButtonText : MonoBehaviour
{
    [SerializeField]
    private string m_KeybordString = "I'm using keyboard";

    [SerializeField]
    private string m_MouseString = "I'm using mouse";

    private TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (GameManager.UseMouse)
        {
            m_Text.text = m_MouseString;
        }
        else
        {
            m_Text.text = m_KeybordString;
        }
    }
}