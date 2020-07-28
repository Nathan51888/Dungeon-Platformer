using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void Start ()
    {
        Rigidbody = GetComponent<Rigidbody2D> ();
    }
    private void FixedUpdate ()
    {
        ChangeJumpGravity ();
    }

    PlayerMovementY _movementY = new PlayerMovementY ();
    public static Rigidbody2D Rigidbody;

    private void ChangeJumpGravity ()
    {
        switch (_movementY.CheckButtonRelease (Rigidbody, PlayerInput.ReleasedJump))
        {
            case true:
                _movementY.SetLowJumpGravity (Rigidbody, PlayerInfo.LowJumpMultiplier);
                break;
            case false:
                _movementY.SetNormalJumpGravity (Rigidbody, PlayerInfo.FallMultiplier);
                break;
        }
    }
}