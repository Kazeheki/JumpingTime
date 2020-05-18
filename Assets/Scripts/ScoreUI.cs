using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_ScoreTextField = null;

    private void OnEnable()
    {
        GameEvents.OnUpdateScoreVisuals += SetScoreText;
    }

    private void OnDisable()
    {
        GameEvents.OnUpdateScoreVisuals -= SetScoreText;
    }

    private void SetScoreText(int score)
    {
        m_ScoreTextField.text = score.ToString();
    }
}