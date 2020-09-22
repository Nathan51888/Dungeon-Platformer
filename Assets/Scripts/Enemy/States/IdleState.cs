using UnityEngine;

namespace Enemy.States
{
    public class IdleState : IEnemyState
    {
        private float _currentAttackCooldown;

        public void Enter(EnemyStateManager stateManager)
        {
            //Animation
            stateManager.Animator.SetBool("IsIdle", true);
            stateManager.Animator.SetBool("IsChasing", false);
            stateManager.Animator.SetBool("IsDashing", false);
            stateManager.IsDashing = false;
            stateManager.Rigidbody2D.velocity = Vector2.zero;
            _currentAttackCooldown = stateManager.AttackCooldown;
        }

        public void Update(EnemyStateManager stateManager)
        {
            if (stateManager.inRange && _currentAttackCooldown <= 0)
                stateManager.TransitionToState(stateManager.ChaseState);
            else
                _currentAttackCooldown -= Time.deltaTime;
        }
    }
}