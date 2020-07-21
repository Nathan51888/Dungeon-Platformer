using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovementY movementY;
    PlayerMovementX movementX;
    PlayerTimer jumpBuffer;

    private void Start()
    {
        movementY = new PlayerMovementY();
        jumpBuffer = new PlayerTimer();
        movementX = new PlayerMovementX();
    }

    [Header("Jump")]
    [SerializeField] float jumpVelocity;

    [Header("Movement")]
    [SerializeField] float maxSpeed;

    // Controller
    float playerAxisX;
    private void Update()
    {
        Jump();
        Move();
    }
    private void Jump()
    {
        if (PlayerInput.JumpPressed())
        {
            movementY.SetVelocityY(PlayerPhysics._rigidbody, jumpVelocity);
            jumpBuffer = new PlayerTimer();
            jumpBuffer.SetJumpBufferTimer();
        }
        else
        {
            jumpBuffer.CheckJumpBufferEnd(Time.deltaTime);
        }
    }
    private void Move()
    {
        playerAxisX = movementX.GetPlayerAxisX(maxSpeed, PlayerInput.HorizontalAxis());
        movementX.SetVelocityX(PlayerPhysics._rigidbody, playerAxisX);
    }
}