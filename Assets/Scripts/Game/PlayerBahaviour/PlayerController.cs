using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        Move();
        Jump();
    }

    PlayerMovementY movementY = new PlayerMovementY();
    PlayerMovementX movementX = new PlayerMovementX();
    
    private void Jump()
    {
        if (PlayerDetection.isGrounded == false)
            return;

        if (PlayerInput.PressedJump)
        {
            movementY.SetVelocityY(PlayerPhysics._rigidbody, PlayerInfo.jumpVelocity);
        }
    }
    private void Move()
    {
        float playerAxisX = movementX.GetPlayerAxisX(PlayerInfo.maxSpeed, PlayerInput.PlayerAxisX);
        movementX.SetVelocityX(PlayerPhysics._rigidbody, playerAxisX);
    }
}