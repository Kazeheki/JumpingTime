using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenShake : MonoBehaviour
{
    [SerializeField]
    private float m_ShakeAmount = 1f;

    [SerializeField]
    private float m_DecreaseAmount = .2f;

    private float m_Shake = 0;

    private Vector3 m_InitialPosition;

    private void OnEnable()
    {
        m_InitialPosition = transform.localPosition;
        GameEvents.OnShakeScreen += OnShake;
    }

    private void OnDisable()
    {
        GameEvents.OnShakeScreen -= OnShake;
    }

    private void OnShake()
    {
        m_Shake = m_ShakeAmount;
    }

    private void Update()
    {
        if (m_Shake > 0 && GameManager.IsGameRunning)
        {
            transform.position += Random.insideUnitSphere * m_ShakeAmount;
            m_Shake -= Time.deltaTime * m_DecreaseAmount;
        }
        else
        {
            m_Shake = 0f;
            transform.localPosition = m_InitialPosition;
        }
    }
}