using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class InstructionsStartText : MonoBehaviour
{
    [SerializeField]
    private string m_MouseText = "- hit left mouse button to continue -";

    [SerializeField]
    private string m_KeyboardText = "- hit space to continue -";

    private TextMeshProUGUI m_Text = null;

    private void Awake()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        if (GameManager.UseMouse)
        {
            m_Text.text = m_MouseText;
        }
        else
        {
            m_Text.text = m_KeyboardText;
        }
    }
}