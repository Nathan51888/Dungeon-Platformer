using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class DashState : IPlayerState
    {
        private float _currentDashTime;

        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.ChangeAnimation(stateManager.PLayerDash);
            _currentDashTime = stateManager.DashTime;
            stateManager.Rigidbody2D.velocity =
                new Vector2(
                    stateManager.transform.localScale.x * stateManager.DashSpeed,
                    0);
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (_currentDashTime > 0)
            {
                _currentDashTime -= Time.deltaTime;
                stateManager.Rigidbody2D.velocity = new Vector2(stateManager.Rigidbody2D.velocity.x, 0);

                if (Keyboard.current.jKey.wasPressedThisFrame && stateManager.IsGrounded)
                    stateManager.TransitionToState(stateManager.RunJumpState);
            }
            else
            {
                stateManager.CurrentDashCooldown = stateManager.DashCooldown;
                stateManager.TransitionToState(stateManager.IdleState);
            }
        }
    }
}