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

    [SerializeField]
    private Difficulty m_Difficulty = null;

    private void Update()
    {
        float calculatedSpeed = m_RotationSpeed;
        if (m_Difficulty != null)
        {
            Debug.Log("Speed Multiplyer: " + m_Difficulty.SpeedMultiplyer);
            calculatedSpeed *= m_Difficulty.SpeedMultiplyer;
        }
        float rotationValue = calculatedSpeed * Time.deltaTime;
        this.transform.rotation *= Quaternion.Euler(m_AroundX ? rotationValue : 0, m_AroundY ? rotationValue : 0, m_AroundZ ? rotationValue : 0);
    }
}