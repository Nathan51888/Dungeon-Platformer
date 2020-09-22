using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyHurtTrigger : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) other.GetComponent<PlayerManager>().TakeDamage(damage);
        }
    }
}