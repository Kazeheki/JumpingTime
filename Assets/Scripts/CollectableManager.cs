using System.Collections;
using UnityEngine;

public class CollectableManager : Spawner<Collectable>
{
    [SerializeField]
    private float m_IntervalInSeconds = 5f;

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
        if (m_SingleSpawn.gameObject.activeInHierarchy)
        {
            return; // don't change if still active.
        }

        m_SingleSpawn.transform.position = GetRandomPosition();
        m_SingleSpawn.gameObject.SetActive(true);
    }
}