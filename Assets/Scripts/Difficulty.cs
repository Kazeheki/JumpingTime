using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [HideInInspector]
    public Difficulty Instance = null;

    [SerializeField]
    private float m_MinSpeedMultiplyer = 1f;

    [SerializeField]
    private float m_MaxSpeedMultiplyer = 3f;

    [SerializeField]
    private CoinsPerLevel[] m_CoinsPerLevel = new CoinsPerLevel[]
    {
        new CoinsPerLevel(1, 5),
        new CoinsPerLevel(2, 10)
    };

    private int m_CurrentLevel = 1;

    private void OnEnable()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Muliple Difficulty objects in the scene. This: " + name + " | Already active instance: " + Instance.name);
            Destroy(this);
            return;
        }

        Instance = this;

        GameEvents.OnUpdateScoreVisuals += CheckForLevelup;
        GameEvents.OnRestart += Reset;
    }

    private void OnDisable()
    {
        Instance = null;

        GameEvents.OnUpdateScoreVisuals -= CheckForLevelup;
        GameEvents.OnRestart -= Reset;
    }

    private void Reset()
    {
        m_CurrentLevel = 1;
    }

    private void CheckForLevelup(int score)
    {
        if (m_CurrentLevel > m_CoinsPerLevel.Length)
        {
            return; // no need to check; max level is reached.
        }

        CoinsPerLevel found = null;
        int index = 0;
        do
        {
            if (m_CoinsPerLevel[index].level == m_CurrentLevel)
            {
                found = m_CoinsPerLevel[index];
            }
            index++;
        } while (found == null && index < m_CoinsPerLevel.Length);

        if (found != null && score >= found.totalAmountForNextLevel)
        {
            m_CurrentLevel++;
        }
    }

    public float SpeedMultiplyer => (m_MaxSpeedMultiplyer - m_MinSpeedMultiplyer) / m_CoinsPerLevel.Length * m_CurrentLevel;

    [System.Serializable]
    private class CoinsPerLevel
    {
        public int level;
        public int totalAmountForNextLevel;

        public CoinsPerLevel(int level, int amount)
        {
            this.level = level;
            this.totalAmountForNextLevel = amount;
        }
    }
}