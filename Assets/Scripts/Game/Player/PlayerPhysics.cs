using UnityEngine;

public class PlayerPhysics : MonoBehaviour 
{
    PlayerMovementY jump;
    public static Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        jump = new PlayerMovementY();
    }

    [Header("Jump")]
    [SerializeField] float lowJumpMultiplier;
    [SerializeField] float fallMultiplier;

    // Physics
    private void FixedUpdate()
    {
        ChangeJumpGravity();
    }

    private void ChangeJumpGravity()
    {
        switch (jump.CheckButtonRelease(_rigidbody, PlayerInput.JumpReleased()))
        {
            case true:
                jump.SetLowJumpGravity(_rigidbody, lowJumpMultiplier);
                break;
            case false:
                jump.SetNormalJumpGravity(_rigidbody, fallMultiplier);
                break;
        }
    }
}