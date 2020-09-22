using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            Time.timeScale = 1;
            stateManager.ChangeAnimation(stateManager.PLayerIdle);
            stateManager.Rigidbody2D.velocity = Vector2.zero;
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            if (!stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.FallState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (Keyboard.current.hKey.wasPressedThisFrame && stateManager.CurrentAttackCooldown <= 0)
            {
                stateManager.TransitionToState(stateManager.AttackState);
                return;
            }

            if (Keyboard.current.jKey.wasPressedThisFrame && stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.IdleJumpState);
            if (Input.GetAxisRaw("Horizontal") != 0 && stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.RunState);
            if (Keyboard.current.kKey.wasPressedThisFrame && stateManager.CurrentDashCooldown <= 0)
                stateManager.TransitionToState(stateManager.DashState);
        }
    }
}