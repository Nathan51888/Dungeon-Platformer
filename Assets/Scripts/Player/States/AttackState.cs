using Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class AttackState : IPlayerState
    {
        private float _currentAttackTime;

        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.AttackParticle.Play();
            stateManager.ChangeAnimation(stateManager.PLayerAttack);
            var detected = Physics2D.OverlapBoxAll(
                stateManager.AttackPoint.transform.position,
                new Vector2(stateManager.AttackRangeX, stateManager.AttackRangeY),
                0, stateManager.EnemyHurtbox);

            foreach (var enemiesToDamage in detected) enemiesToDamage.GetComponent<IDamageable>().TakeDamage(1);
            _currentAttackTime = 0.45f;
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
        }

        public void Update(PlayerStateManager stateManager)
        {
            stateManager.Rigidbody2D.velocity = new Vector2(
                Input.GetAxisRaw("Horizontal") * stateManager.MoveSpeed,
                stateManager.Rigidbody2D.velocity.y);
            if (Keyboard.current.jKey.wasPressedThisFrame && stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.RunJumpState);
            stateManager.CurrentAttackCooldown = stateManager.AttackCooldown;
            if (_currentAttackTime > 0)
                _currentAttackTime -= Time.deltaTime;
            else
                stateManager.TransitionToState(stateManager.IdleState);
        }
    }
}