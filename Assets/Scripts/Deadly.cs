using UnityEngine;

public class Deadly : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.HitDeadly();
        }
    }
}