using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerGravity : MonoBehaviour
    {
        #region Variables

        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float jumpGravity;
        [SerializeField] private float fallGravity;
        [SerializeField] private float lowJumpGravity;

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody2D.velocity.y < 0)
                _rigidbody2D.gravityScale = fallGravity;
            else if (!Keyboard.current.jKey.isPressed && _rigidbody2D.velocity.y > 0)
                _rigidbody2D.gravityScale = lowJumpGravity;
            else
                _rigidbody2D.gravityScale = jumpGravity;
        }

        #endregion
    }
}