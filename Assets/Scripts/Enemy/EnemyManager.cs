using Game;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        private int _currentHealth;

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                Destroy(gameObject);
        }
    }
}