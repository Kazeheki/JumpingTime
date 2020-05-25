using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyManager : Spawner<Follower>
{
    [SerializeField]
    private float m_IntervalInSeconds = 10f;

    [SerializeField]
    private Transform m_Target = null;

    [SerializeField]
    private float m_SafetyRadius = 1f;

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
        if (m_SingleSpawn.gameObject.activeInHierarchy)
        {
            return; // don't change if still active.
        }

        Vector3 position;
        do
        {
            position = GetRandomPosition();
        } while (Vector3.Distance(m_Target.position, position) < m_SafetyRadius);

        m_SingleSpawn.transform.position = position;
        m_SingleSpawn.gameObject.SetActive(true);
        m_SingleSpawn.SetTarget(m_Target);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        DrawBasicRadius();

        Handles.color = Color.green;
        Handles.DrawWireDisc(m_Target.position, Vector3.up, m_SafetyRadius);
    }

#endif
}