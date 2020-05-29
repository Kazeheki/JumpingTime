using UnityEngine;
using UnityEngine.InputSystem;

public class DevMode : MonoBehaviour
{
    public static bool IsActive = false;
    private static DevMode m_Instance = null;

    [SerializeField]
    private bool m_GodMode = true;

    [SerializeField]
    private bool m_CoinAdding = true;

    [SerializeField]
    private bool m_StopMouseFollow = true;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (m_Instance != null)
        {
            Debug.LogWarning("Multiple DevMode Objects in the scene. This: " + this.name + " | already enabled instance: " + m_Instance.name);
            Destroy(this);
            return;
        }

        IsActive = true;
        m_Instance = this;
    }

    private void OnDisable()
    {
        IsActive = false;
        m_Instance = null;
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            return;
        }

        if (keyboard.aKey.wasPressedThisFrame && m_CoinAdding)
        {
            GameEvents.IncreaseScore(1);
        }
    }

    public static bool IsGodModeActivated => m_Instance.m_GodMode;

    public static bool IsMouseFollowingStopped => m_Instance.m_StopMouseFollow;
}