using UnityEngine;

namespace Player.States
{
    public class HurtState : IPlayerState
    {
        private float _currentDuration;
        private readonly float _maxDuration = 0.4f;
        private float _t;

        public void Enter(PlayerStateManager stateManager)
        {
            stateManager.HurtParticle.Play();
            stateManager.Rigidbody2D.velocity = Vector2.zero;
            _currentDuration = _maxDuration;
            _t = 0.1f;
            Time.timeScale = 0;
        }

        public void OnDetected(PlayerStateManager stateManager)
        {
        }

        public void Update(PlayerStateManager stateManager)
        {
            if (_currentDuration > 0)
            {
                stateManager.Rigidbody2D.velocity = new Vector2(
                    Input.GetAxisRaw("Horizontal") * stateManager.MoveSpeed,
                    stateManager.Rigidbody2D.velocity.y);
                _t += 2f * Time.deltaTime;
                Time.timeScale = Mathf.Lerp(0, 1, _t);
                _currentDuration -= Time.deltaTime;
            }
            else
            {
                stateManager.TransitionToState(stateManager.IdleState);
            }
        }
    }
}