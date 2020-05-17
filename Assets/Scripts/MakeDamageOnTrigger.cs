using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField]
    private int m_Damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameEvents.Hit(m_Damage);
        }
    }
}