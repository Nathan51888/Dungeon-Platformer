using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class RunJumpState : IPlayerState
    {
        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.ChangeAnimation(stateManager.PLayerRunJump);
            stateManager.Rigidbody2D.velocity =
                new Vector2(
                    stateManager.Rigidbody2D.velocity.x,
                    stateManager.JumpVelocity);
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (stateManager.Rigidbody2D.velocity.y <= 0)
            {
                stateManager.TransitionToState(stateManager.FallState);
            }
            else
            {
                if (Keyboard.current.hKey.wasPressedThisFrame && stateManager.CurrentAttackCooldown <= 0)
                    stateManager.TransitionToState(stateManager.AttackState);
                stateManager.Rigidbody2D.velocity =
                    new Vector2(
                        Input.GetAxisRaw("Horizontal") * stateManager.MoveSpeed,
                        stateManager.Rigidbody2D.velocity.y);
                if (Keyboard.current.kKey.wasPressedThisFrame && stateManager.CurrentDashCooldown <= 0)
                    stateManager.TransitionToState(stateManager.DashState);
            }
        }
    }
}