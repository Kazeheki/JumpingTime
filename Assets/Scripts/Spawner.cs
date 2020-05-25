using UnityEditor;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T m_Prefab = null;

    [SerializeField]
    private float m_Radius = 1f;

    [SerializeField]
    private float m_OffsetY = 0f;

    [SerializeField]
    private Vector3 m_AreaOrigin = Vector3.zero;

    [SerializeField]
    protected Transform m_Parent;

    protected T m_SingleSpawn = null;

    private void Awake()
    {
        CreateInstance();
    }

    private void OnEnable()
    {
        GameEvents.OnRestart += Reset;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= Reset;
    }

    protected Vector3 GetRandomPosition()
    {
        Vector3 position = Random.insideUnitCircle * m_Radius;
        // insideUnitCircle will only set x and y
        // spawning object will move on x and z axis though.
        position.z = position.y;
        position.y = m_Prefab.transform.position.y + m_OffsetY;
        position += m_AreaOrigin;
        return position;
    }

    protected void Reset()
    {
        m_SingleSpawn.gameObject.SetActive(false);
    }

    protected void CreateInstance()
    {
        m_SingleSpawn = Instantiate(m_Prefab, m_Prefab.transform.position, m_Prefab.transform.rotation, m_Parent);
        if (m_SingleSpawn == null)
        {
            Debug.LogError("Couldn't instantiate prefab! " + m_Prefab.name);
        }

        m_SingleSpawn.gameObject.SetActive(false);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        DrawBasicRadius();
    }

    protected void DrawBasicRadius()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(m_AreaOrigin, Vector3.up, m_Radius);
    }

#endif
}