using System.Collections;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int m_CurrentScore = 0;

    private void Start()
    {
        StartCoroutine(NotifyWatchersWithYield());
    }

    private void OnEnable()
    {
        GameEvents.OnIncreaseScore += OnIncrease;
        GameEvents.OnRestart += Reset;
    }

    private void OnDisable()
    {
        GameEvents.OnIncreaseScore -= OnIncrease;
        GameEvents.OnRestart -= Reset;
    }

    private IEnumerator NotifyWatchersWithYield()
    {
        yield return 0;
        NotifyWatchers();
    }

    private void Reset()
    {
        m_CurrentScore = 0;
        NotifyWatchers();
    }

    private void OnIncrease(int amount)
    {
        m_CurrentScore += amount;
        NotifyWatchers();
    }

    private void NotifyWatchers()
    {
        GameEvents.UpdateScoreVisuals(m_CurrentScore);
    }
}