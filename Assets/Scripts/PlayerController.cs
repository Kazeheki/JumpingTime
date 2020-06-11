using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera m_Camera = null;

    [SerializeField]
    private float m_FallMultiplier = 1f;

    [SerializeField]
    private float m_JumpPower = 1f;

    [SerializeField]
    private float m_MovementSpeed = 1f;

    [SerializeField]
    private bool m_UseMouse = true;

    private Rigidbody m_Rigidbody = null;
    private Vector2 m_KeyboardDirection = Vector2.zero;

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started || GameManager.IsGamePaused)
        {
            return;
        }

        if (m_Rigidbody.velocity.y == 0)
        {
            m_Rigidbody.AddForce(0, m_JumpPower, 0, ForceMode.Impulse);
            AudioManager.Instance.Play("Jumping");
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (GameManager.IsGameOver)
        {
            return;
        }

        m_KeyboardDirection = context.ReadValue<Vector2>();
    }

    private void Fall()
    {
        if (m_Rigidbody.velocity.y < 0)
        {
            m_Rigidbody.velocity += Vector3.up * Physics.gravity.y * m_FallMultiplier * Time.deltaTime;
        }
    }

    private void MoveWithKeyboard()
    {
        var x = transform.position.x + (m_KeyboardDirection.normalized.x * m_MovementSpeed * Time.deltaTime);
        var z = transform.position.z + (m_KeyboardDirection.normalized.y * m_MovementSpeed * Time.deltaTime);
        transform.position = new Vector3(x, transform.position.y, z);
    }

    private void FollowMouse()
    {
        if (DevMode.IsActive && DevMode.IsMouseFollowingStopped)
        {
            return;
        }

        Vector2 mousePosition = new Vector2(Pointer.current.position.x.ReadValue(), Pointer.current.position.y.ReadValue());
        Ray ray = m_Camera.ScreenPointToRay(mousePosition);
        // fill all bits of 8 layers
        int layerMask = 255;
        // remove bit of "Ignore Raycast"
        layerMask -= LayerMask.NameToLayer("Ignore Raycast");

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Vector3 newPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, newPosition, Time.deltaTime * m_MovementSpeed);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Fall();
        if (m_UseMouse)
        {
            FollowMouse();
        }
        else
        {
            MoveWithKeyboard();
        }
    }
}