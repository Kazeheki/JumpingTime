using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Collectable : MonoBehaviour
{
    [SerializeField]
    private float m_TimeToLive = 2f;

    [SerializeField]
    private float m_TimeForIndication = .5f;

    [SerializeField]
    private float m_BlinkInterval = .1f;

    private void OnEnable()
    {
        GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(DisappearingRoutine());
    }

    private IEnumerator DisappearingRoutine()
    {
        yield return new WaitForSeconds(m_TimeToLive - m_TimeForIndication);
        IndicateDisapearance();

        yield return new WaitForSeconds(m_TimeForIndication);
        Disapear();
    }

    private void IndicateDisapearance()
    {
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (this.gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(m_BlinkInterval);
            GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        }
    }

    private void Disapear()
    {
        this.gameObject.SetActive(false);
    }
}