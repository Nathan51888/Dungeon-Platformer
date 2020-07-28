using UnityEngine;

public static class PlayerInfo
{
    // Jump
    public static float JumpVelocity = 26;
    public static float LowJumpMultiplier = 16;
    public static float FallMultiplier = 4;
    // Movement
    public static float MaxSpeed = 10;
    // Status
    public static int MaxHealth = 10;
    public static bool IsGrounded;
    public static bool IsFacingRight = true;
    // Timers
    public static float MaxJumpBufferTime = 0.1f;
    public static float MaxGroundBufferTime = 0.1f;
    public static float MaxAttackBufferTime = 0.5f;
}