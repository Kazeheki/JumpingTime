using UnityEngine;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextField = null;

    private void OnEnable()
    {
        GameEvents.OnFinalScore += ChangeScore;
    }

    private void OnDisable()
    {
        GameEvents.OnFinalScore -= ChangeScore;
    }

    private void ChangeScore(int score)
    {
        m_TextField.text = score.ToString();
    }
}