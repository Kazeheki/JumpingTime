using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthListener : MonoBehaviour
{
    private List<Heart> m_hearts = new List<Heart>();

    private void OnEnable()
    {
        GameEvents.OnHealthChanged += OnChange;
    }

    private void OnDisable()
    {
        GameEvents.OnHealthChanged -= OnChange;
    }

    private void OnChange(int current, int max)
    {
        if (max < m_hearts.Count())
        {
            m_hearts = m_hearts.GetRange(0, max);
        }
        else if (max > m_hearts.Count())
        {
            while (m_hearts.Count() < max)
            {
                m_hearts.Add(((GameObject)Instantiate(Resources.Load("Prefabs/Heart"), transform)).GetComponent<Heart>());
            }
        }

        for (int i = 0; i < m_hearts.Count(); i++)
        {
            m_hearts[i].SetFilled(i >= max - current);
        }
    }
}