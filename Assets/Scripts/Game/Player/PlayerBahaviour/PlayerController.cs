using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        Move();
        FlipPlayer();
        Jump();
    }

    PlayerMovementY _movementY = new PlayerMovementY();
    PlayerMovementX _movementX = new PlayerMovementX();
    
    private void Jump()
    {
        if (PlayerInfo.IsGrounded == false)
            return;

        if (PlayerInput.PressedJump)
        {
            _movementY.SetVelocityY(PlayerPhysics.Rigidbody, PlayerInfo.JumpVelocity);
        }
    }
    private void Move()
    {
        float playerAxisX = _movementX.GetPlayerAxisX(PlayerInfo.MaxSpeed, PlayerInput.PlayerAxisX);
        _movementX.SetVelocityX(PlayerPhysics.Rigidbody, playerAxisX);
    }
    private void FlipPlayer()
    {
        if (PlayerInfo.IsFacingRight && PlayerInput.PlayerAxisX < 0)
        {
            GameFunctions.Flip(transform);
            PlayerInfo.IsFacingRight = !PlayerInfo.IsFacingRight;
        }
        else if (!PlayerInfo.IsFacingRight && PlayerInput.PlayerAxisX > 0)
        {
            GameFunctions.Flip(transform);
            PlayerInfo.IsFacingRight = !PlayerInfo.IsFacingRight;
        }
    }
}