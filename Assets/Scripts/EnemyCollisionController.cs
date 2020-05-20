using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<Follower>().gameObject.SetActive(false);
            GameEvents.Hit(1);
        }
    }
}