using System.Collections;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    [SerializeField]
    private Collectable m_CollectablePrefab = null;

    [SerializeField]
    private Transform m_Parent = null;

    [SerializeField]
    private float m_IntervalInSeconds = 5f;

    [SerializeField]
    private Vector3 m_AreaOrigin = Vector3.zero;

    [SerializeField]
    private float m_Radius = 1f;

    [SerializeField]
    private float m_OffsetY = 0f;

    private Collectable m_CurrentCollectable = null;

    private void Awake()
    {
        m_CurrentCollectable = Instantiate(m_CollectablePrefab, m_CollectablePrefab.transform.position, m_CollectablePrefab.transform.rotation, m_Parent);
        if (m_CurrentCollectable == null)
        {
            Debug.LogError("Couldn't instantiate collectable!");
        }
        m_CurrentCollectable.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_IntervalInSeconds);
            SpawnCollectable();
        }
    }

    private void SpawnCollectable()
    {
        if (m_CurrentCollectable.gameObject.activeInHierarchy)
        {
            return; // don't change if still active.
        }

        Vector3 position = Random.insideUnitCircle * m_Radius;
        // insideUnitCircle will only set x and y
        // collectable will move on x and z axis though.
        position.z = position.y;
        position.y = m_CollectablePrefab.transform.position.y + m_OffsetY;
        position += m_AreaOrigin;
        m_CurrentCollectable.transform.position = position;
        m_CurrentCollectable.gameObject.SetActive(true);
    }
}