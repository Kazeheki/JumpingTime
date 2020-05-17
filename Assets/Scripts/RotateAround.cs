using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField]
    private float m_RotationSpeed = 1f;

    [SerializeField]
    private bool m_AroundX = false;

    [SerializeField]
    private bool m_AroundY = true;

    [SerializeField]
    private bool m_AroundZ = false;

    private void Update()
    {
        float rotationValue = m_RotationSpeed * Time.deltaTime;
        this.transform.rotation *= Quaternion.Euler(m_AroundX ? rotationValue : 0, m_AroundY ? rotationValue : 0, m_AroundZ ? rotationValue : 0);
    }
}