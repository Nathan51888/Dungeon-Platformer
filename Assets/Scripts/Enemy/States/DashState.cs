using UnityEngine;

namespace Enemy.States
{
    public class DashState : IEnemyState
    {
        private readonly float _chargeUpTime = 0.2f;
        private float _currentChargeUpTime;
        private float _currentDashTime;

        public void Enter(EnemyStateManager stateManager)
        {
            //Animation
            stateManager.Animator.SetBool("IsIdle", false);
            stateManager.Animator.SetBool("IsChasing", false);
            stateManager.Animator.SetBool("IsDashing", false);
            _currentDashTime = stateManager.DashTime;
            _currentChargeUpTime = _chargeUpTime;
            stateManager.IsDashing = true;
            stateManager.Rigidbody2D.velocity =
                new Vector2(
                    stateManager.transform.localScale.x * stateManager.DashSpeed,
                    stateManager.Rigidbody2D.velocity.y);
        }

        public void Update(EnemyStateManager stateManager)
        {
            if (_currentChargeUpTime > 0)
            {
                _currentChargeUpTime -= Time.deltaTime;
                stateManager.Animator.SetBool("IsDashing", true);
            }

            if (_currentDashTime > 0 && _currentChargeUpTime <= 0)
            {
                _currentDashTime -= Time.deltaTime;
                stateManager.Rigidbody2D.velocity = new Vector2(
                    stateManager.transform.localScale.x * stateManager.DashSpeed,
                    stateManager.Rigidbody2D.velocity.y);
            }
            else if (_currentDashTime <= 0 || !stateManager.inRange)
            {
                stateManager.IsDashing = false;
                stateManager.TransitionToState(stateManager.IdleState);
            }
        }
    }
}