using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class FallState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.ChangeAnimation(stateManager.PLayerFall);
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            if (stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.IdleState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (Keyboard.current.hKey.wasPressedThisFrame && stateManager.CurrentAttackCooldown <= 0)
                stateManager.TransitionToState(stateManager.AttackState);
            stateManager.Rigidbody2D.velocity = new Vector2(
                Input.GetAxisRaw("Horizontal") * stateManager.MoveSpeed,
                stateManager.Rigidbody2D.velocity.y);
            if (Keyboard.current.kKey.wasPressedThisFrame && stateManager.CurrentDashCooldown <= 0)
                stateManager.TransitionToState(stateManager.DashState);
        }
    }
}