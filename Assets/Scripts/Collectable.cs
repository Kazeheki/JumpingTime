using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private float m_TimeToLive = 2f;

    [SerializeField]
    private float m_TimeForIndication = .5f;

    [SerializeField]
    private float m_BlinkInterval = .1f;

    [SerializeField]
    private int m_ScoreValue = 1;

    private void OnEnable()
    {
        if (GetComponentInChildren<MeshRenderer>() == null)
        {
            throw new System.Exception("SETUP EXCEPTION: Collectable doesn't have child with MeshRenderer||name: " + name);
        }
        GetComponentInChildren<MeshRenderer>().enabled = true;
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
            GetComponentInChildren<MeshRenderer>().enabled = !GetComponentInChildren<MeshRenderer>().enabled;
        }
    }

    private void Disapear()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.IncreaseScore(m_ScoreValue);
            AudioManager.Instance.Play("CoinCollect");
            Disapear();
        }
    }
}