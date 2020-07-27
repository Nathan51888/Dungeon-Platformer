using UnityEngine;

public class PlayerMovementY
{
    public void SetNormalJumpGravity(Rigidbody2D rigidbody, float fallMultiplier)
    {
        rigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier* Time.deltaTime;

    }
    public void SetLowJumpGravity(Rigidbody2D rigidbody, float lowJumpMultiplier)
    {
        rigidbody.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
    }
    public bool CheckButtonRelease(Rigidbody2D rigidbody, bool releasedJump)
    {
        if (rigidbody.velocity.y > 0 && releasedJump)
            return true;

        return false;
    }
    public void SetVelocityY(Rigidbody2D rigidbody, float jumpVelocity)
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpVelocity);
    }
}