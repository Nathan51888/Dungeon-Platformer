using UnityEngine;

public class PlayerMovementX
{
    public float GetPlayerAxisX (float maxSpeed, float inputAxis)
    {
        float playerAxisX = maxSpeed * inputAxis;
        return playerAxisX;
    }
    public void SetVelocityX (Rigidbody2D rigidbody, float playerAxisX)
    {
        rigidbody.velocity = new Vector2 (playerAxisX, rigidbody.velocity.y);
    }
}