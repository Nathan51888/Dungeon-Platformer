using UnityEngine;

namespace Enemy.States
{
    public class ChaseState : IEnemyState
    {
        public void Enter(EnemyStateManager stateManager)
        {
            //Animation
            stateManager.Animator.SetBool("IsIdle", false);
            stateManager.Animator.SetBool("IsChasing", true);
            stateManager.Animator.SetBool("IsDashing", false);
        }

        public void Update(EnemyStateManager stateManager)
        {
            var distance = Vector2.Distance(stateManager.transform.position, stateManager.Player.transform.position);

            if (!stateManager.inRange)
                stateManager.TransitionToState(stateManager.IdleState);
            else if (distance <= stateManager.AttackDistance)
                stateManager.TransitionToState(stateManager.DashState);

            if (stateManager.Player.transform.position.x > stateManager.transform.position.x)
                stateManager.Rigidbody2D.velocity =
                    new Vector2(
                        stateManager.MoveSpeed,
                        stateManager.Rigidbody2D.velocity.y);
            else if (stateManager.Player.transform.position.x < stateManager.transform.position.x)
                stateManager.Rigidbody2D.velocity =
                    new Vector2(
                        -stateManager.MoveSpeed,
                        stateManager.Rigidbody2D.velocity.y);
        }
    }
}