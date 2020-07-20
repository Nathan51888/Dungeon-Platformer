using UnityEngine;

public class PlayerPhysics : MonoBehaviour 
{
    PlayerMovementY jump;
    public static Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        jump = new PlayerMovementY(_rigidbody);
    }

    // Physics
    private void FixedUpdate()
    {
        ChangeJumpGravity();
    }

    private void ChangeJumpGravity()
    {
        switch (jump.CheckButtonRelease(PlayerInput.JumpReleased()))
        {
            case true:
                jump.SetLowJumpGravity(lowJumpMultiplier);
                break;
            case false:
                jump.SetNormalJumpGravity(fallMultiplier);
                break;
        }
    }
}