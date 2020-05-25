using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Follower m_EnemyPrefab = null;

    [SerializeField]
    private float m_IntervalInSeconds = 10f;

    [SerializeField]
    private Vector3 m_AreaOrigin = Vector3.zero;

    [SerializeField]
    private float m_Radius = 1f;

    [SerializeField]
    private float m_OffsetY = 0f;

    [SerializeField]
    private Transform m_Target = null;

    [SerializeField]
    private float m_SafetyRadius = 1f;

    private Follower m_CurrentEnemy = null;

    private void Awake()
    {
        m_CurrentEnemy = Instantiate(m_EnemyPrefab, m_EnemyPrefab.transform.position, m_EnemyPrefab.transform.rotation);
        if (m_CurrentEnemy == null)
        {
            Debug.LogError("Couldn't instantiate collectable!");
        }
        m_CurrentEnemy.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnRestart += Reset;
    }

    private void OnDisable()
    {
        GameEvents.OnRestart -= Reset;
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
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (m_CurrentEnemy.gameObject.activeInHierarchy)
        {
            return; // don't change if still active.
        }

        Vector3 position;
        do
        {
            position = GetRandomPossitionWithOffset();
        } while (Vector3.Distance(m_Target.position, position) < m_SafetyRadius);

        m_CurrentEnemy.transform.position = position;
        m_CurrentEnemy.gameObject.SetActive(true);
        m_CurrentEnemy.SetTarget(m_Target);
    }

    private Vector3 GetRandomPossitionWithOffset()
    {
        Vector3 position = Random.insideUnitCircle * m_Radius;
        // insideUnitCircle will only set x and y
        // collectable will move on x and z axis though.
        position.z = position.y;
        position.y = m_EnemyPrefab.transform.position.y + m_OffsetY;
        position += m_AreaOrigin;
        return position;
    }

    private void Reset()
    {
        m_CurrentEnemy.gameObject.SetActive(false);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(m_AreaOrigin, Vector3.up, m_Radius);

        Handles.color = Color.green;
        Handles.DrawWireDisc(m_Target.position, Vector3.up, m_SafetyRadius);
    }

#endif
}