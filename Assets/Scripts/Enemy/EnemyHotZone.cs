using UnityEngine;

namespace Enemy
{
    public class EnemyHotZone : MonoBehaviour
    {
        private EnemyStateManager _stateManager;

        private void Awake()
        {
            _stateManager = GetComponentInParent<EnemyStateManager>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;

            _stateManager.inRange = false;
            _stateManager.TiggerArea.SetActive(true);
            _stateManager.HotArea.SetActive(false);
        }
    }
}