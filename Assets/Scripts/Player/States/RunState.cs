using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class RunState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.ChangeAnimation(stateManager.PLayerRun);
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
            if (!stateManager.IsGrounded)
                stateManager.TransitionToState(stateManager.FallState);
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                stateManager.TransitionToState(stateManager.IdleState);
            }
            else
            {
                if (Keyboard.current.hKey.wasPressedThisFrame && stateManager.CurrentAttackCooldown <= 0)
                {
                    stateManager.TransitionToState(stateManager.AttackState);
                    return;
                }

                if (Keyboard.current.jKey.wasPressedThisFrame && stateManager.IsGrounded)
                    stateManager.TransitionToState(stateManager.RunJumpState);

                stateManager.Rigidbody2D.velocity = new Vector2(
                    Input.GetAxisRaw("Horizontal") * stateManager.MoveSpeed,
                    stateManager.Rigidbody2D.velocity.y);
                if (Keyboard.current.kKey.wasPressedThisFrame && stateManager.CurrentDashCooldown <= 0)
                    stateManager.TransitionToState(stateManager.DashState);
            }
        }
    }
}