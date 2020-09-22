using UnityEngine;

namespace Enemy
{
    public class EnemySprite : MonoBehaviour
    {
        private bool _isFacingRight = true;
        private GameObject _player;
        private EnemyStateManager _stateManager;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _stateManager = GetComponent<EnemyStateManager>();
        }

        private void Update()
        {
            FlipEnemy();
        }

        private void FlipEnemy()
        {
            if (_stateManager.IsDashing) return;

            if (_isFacingRight && _player.transform.position.x < transform.position.x)
            {
                FlipTransform(transform);
                _isFacingRight = !_isFacingRight;
            }
            else if (!_isFacingRight && _player.transform.position.x > transform.position.x)
            {
                FlipTransform(transform);
                _isFacingRight = !_isFacingRight;
            }
        }

        private void FlipTransform(Transform transformToFlip)
        {
            var theScale = transformToFlip.localScale;
            theScale.x *= -1;
            transformToFlip.localScale = theScale;
        }
    }
}