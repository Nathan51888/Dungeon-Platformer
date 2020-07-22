using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        Move();
        Jump();
    }

    PlayerTimer jumpBuffer = new PlayerTimer();

    private void Jump()
    {
        if (PlayerDetection.isGrounded == false)
            return;

        if (PlayerInput.GetJumpPressed())
        {
            movementY.SetVelocityY(PlayerPhysics._rigidbody, PlayerInfo.jumpVelocity);
            jumpBuffer = new PlayerTimer();
            jumpBuffer.SetJumpBufferTimer();
        }
        else
            jumpBuffer.CheckJumpBufferEnd(Time.deltaTime);
    }
    PlayerMovementY movementY = new PlayerMovementY();
    PlayerMovementX movementX = new PlayerMovementX();
    
    private void Move()
    {
        float playerAxisX = movementX.GetPlayerAxisX(PlayerInfo.maxSpeed, PlayerInput.GetHorizontalAxis());
        movementX.SetVelocityX(PlayerPhysics._rigidbody, playerAxisX);
    }
}