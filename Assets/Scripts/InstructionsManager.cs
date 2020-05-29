using UnityEngine;
using UnityEngine.InputSystem;

public class InstructionsManager : MonoBehaviour
{
    [SerializeField]
    private InputAction m_StartAction;

    private void Awake()
    {
        gameObject.SetActive(true);
        GameEvents.PauseGame();

        m_StartAction.performed += OnClickStart;
        m_StartAction.Enable();
    }

    private void OnClickStart(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed)
        {
            return;
        }

        GameEvents.ResumeGame();

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        m_StartAction.Disable();
    }
}