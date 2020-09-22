using UnityEngine;

namespace Enemy
{
    public class EnemyTriggerArea : MonoBehaviour
    {
        private EnemyStateManager _stateManager;

        private void Awake()
        {
            _stateManager = GetComponentInParent<EnemyStateManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            _stateManager.inRange = true;
            _stateManager.TiggerArea.SetActive(false);
            _stateManager.HotArea.SetActive(true);
        }
    }
}