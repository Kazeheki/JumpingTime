using UnityEngine;

public class ResetTranformOnRestart : MonoBehaviour
{
    private Vector3 m_InitialPosition;
    private Quaternion m_InitialRotation;

    private void Awake()
    {
        m_InitialPosition = transform.position;
        m_InitialRotation = transform.rotation;
    }

    private void OnEnable()
    {
        GameEvents.OnRestart += Reset;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= Reset;
    }

    private void Reset()
    {
        transform.position = m_InitialPosition;
        transform.rotation = m_InitialRotation;
    }
}