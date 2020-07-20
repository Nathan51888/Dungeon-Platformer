using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerMovementY movementY;
    PlayerMovementX movementX;
    PlayerTimer jumpBuffer;

    private void Start()
    {
        movementY = new PlayerMovementY(PlayerPhysics._rigidbody);
        movementX = new PlayerMovementX(PlayerPhysics._rigidbody);
    }

    [Header("Jump")]
    [SerializedField] float lowJumpMultiplier;
    [SerializedField] float fallMultiplier;
    [SerializedField] float jumpVelocity;

    [Header("Movement")]
    [SerializedField] float maxSpeed;

    // Controller
    private void Update()
    {
        Jump();
    }
    private void Jump()
    {
        if (PlayerInput.JumpPressed())
        {
            movementY.SetVelocityY(jumpVelocity);
            SetJumpTimer();
        }
        else
        {
            CheckJumpTimer();
        }
    }
    private void SetJumpTimer()
    {
        jumpBuffer = new PlayerTimer();
        jumpBuffer.SetJumpBufferTimer();
    }
    private void CheckJumpTimer()
    {
        jumpBuffer.CheckJumpBufferEnd();
    }
}