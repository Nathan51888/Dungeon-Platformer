using UnityEngine;

public class PlayerMovementX
{
    private Rigidbody2D _rigidbody;
    public PlayerMovementX(Rigidbody2D rigidbody)
    {
        _rigidbody = rigidbody;
    }
    
    public float PlayerAxisX(float maxSpeed, float inputAxis)
    {
        float playerAxisX = maxSpeed * inputAxis;
        return playerAxisX;
    }
    public void SetVelocityX(Rigidbody2D rigidbody, float playerAxisX)
    {
        rigidbody.velocity = new Vector2(playerAxisX, rigidbody.velocity.y);
    }
}