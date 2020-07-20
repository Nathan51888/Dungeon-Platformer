using UnityEngine;

public class PlayerMovementY
{
    private Rigidbody2D _rigidbody;
    public PlayerMovementY(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }

    public void SetNormalJumpGravity(float fallMultiplier)
    {
        _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier* Time.deltaTime;

    }
    public void SetLowJumpGravity(float lowJumpMultiplier)
    {
        _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
    }
    public bool CheckButtonRelease(bool releasedJump)
    {
        if (_rigidbody.velocity.y > 0 && !releasedJump)
            return true;

        return false;
    }
    public void SetVelocityY(float jumpVelocity)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpVelocity);
    }
}