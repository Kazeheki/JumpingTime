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

    private Rigidbody m_Rigidbody = null;

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started)
        {
            return;
        }
        if (m_Rigidbody.velocity.y == 0)
        {
            m_Rigidbody.AddForce(0, m_JumpPower, 0, ForceMode.Impulse);
            AudioManager.Instance.Play("Jumping");
        }
    }

    private void Fall()
    {
        if (m_Rigidbody.velocity.y < 0)
        {
            m_Rigidbody.velocity += Vector3.up * Physics.gravity.y * m_FallMultiplier * Time.deltaTime;
        }
    }

    private void FollowMouse()
    {
        if (DevMode.IsActive && DevMode.IsMouseFollowingStopped)
        {
            return;
        }

        Vector2 mousePosition = new Vector2(Pointer.current.position.x.ReadValue(), Pointer.current.position.y.ReadValue());
        Ray ray = m_Camera.ScreenPointToRay(mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(hit.point.x, this.transform.position.y, hit.point.z), Time.deltaTime * m_MovementSpeed);
        }
    }

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Fall();
        FollowMouse();
    }
}