using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int m_MaxHealth = 10;

    private int m_CurrentHealth = 10;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;

        StartCoroutine(FirstNotifyWithWait());
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0)
        {
            GameEvents.EndGame();
        }
    }

    private void OnDeadlyHit()
    {
        m_CurrentHealth = 0;
        NotifyListeners();
    }

    private void OnDisable()
    {
        GameEvents.OnDeadlyHit -= OnDeadlyHit;
        GameEvents.OnHit -= OnHit;
        GameEvents.OnRestart -= OnRestart;
        GameEvents.OnIncreaseHealth -= OnIncreaseHealth;
    }

    private void OnEnable()
    {
        GameEvents.OnDeadlyHit += OnDeadlyHit;
        GameEvents.OnHit += OnHit;
        GameEvents.OnRestart += OnRestart;
        GameEvents.OnIncreaseHealth += OnIncreaseHealth;
    }

    private IEnumerator FirstNotifyWithWait()
    {
        yield return 0;

        NotifyListeners();
    }

    private void OnHit(int damage)
    {
        m_CurrentHealth -= damage;
        if (m_CurrentHealth < 0)
        {
            m_CurrentHealth = 0;
        }

        AudioManager.Instance.Play("Damage");
        GameEvents.ShakeScreen();

        NotifyListeners();
    }

    private void OnRestart()
    {
        m_CurrentHealth = m_MaxHealth;
        NotifyListeners();
    }

    private void OnIncreaseHealth(int amount)
    {
        if (m_CurrentHealth + amount > m_MaxHealth)
        {
            m_CurrentHealth = m_MaxHealth;
        }
        else
        {
            m_CurrentHealth += amount;
        }
        NotifyListeners();
    }

    private void NotifyListeners()
    {
        GameEvents.HealthChange(m_CurrentHealth, m_MaxHealth);
    }
}