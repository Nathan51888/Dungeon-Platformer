using UnityEngine;

public class PlayerTimer
{
    public float maxJumpBufferTime = 0.1f;
    Timer jumpBufferTimer;

    public void SetJumpBufferTimer()
    {
        jumpBufferTimer = new Timer(maxJumpBufferTime);
    }
    private bool TickJumpBuffer(float deltaTime)
    {
        bool timerStatus = jumpBufferTimer.Tick(deltaTime);
        return timerStatus;
    }
    public bool CheckJumpBufferEnd(float deltaTime)
    {
        bool timerEnd = TickJumpBuffer(deltaTime);
        return timerEnd;
    }
}