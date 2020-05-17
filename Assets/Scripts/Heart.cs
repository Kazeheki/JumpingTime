using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField]
    private Color m_FilledColor = Color.red;

    [SerializeField]
    private Color m_EmptyColor = Color.gray;

    private Image m_Image = null;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        m_Image.color = m_FilledColor;
    }

    public void SetFilled(bool isFilled)
    {
        m_Image.color = isFilled ? m_FilledColor : m_EmptyColor;
    }
}