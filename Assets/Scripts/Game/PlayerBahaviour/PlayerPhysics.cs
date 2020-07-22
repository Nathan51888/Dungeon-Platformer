using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        ChangeJumpGravity();
    }

    PlayerMovementY jump = new PlayerMovementY();
    public static Rigidbody2D _rigidbody;

    private void ChangeJumpGravity()
    {
        switch (jump.CheckButtonRelease(_rigidbody, PlayerInput.GetJumpReleased()))
        {
            case true:
                jump.SetLowJumpGravity(_rigidbody, PlayerInfo.lowJumpMultiplier);
                break;
            case false:
                jump.SetNormalJumpGravity(_rigidbody, PlayerInfo.fallMultiplier);
                break;
        }
    }
}