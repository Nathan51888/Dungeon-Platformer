using UnityEngine;

public class PlayerTimer
{
    public float maxJumpBufferTime;
    Timer jumpBufferTimer;

    public void SetJumpBufferTimer()
    {
        jumpBufferTimer = new Timer(maxJumpBufferTime);
    }
    private bool TickJumpBuffer()
    {
        bool timerStatus = jumpBufferTimer.Tick(Time.deltaTime);
        return timerStatus;
    }
    public bool CheckJumpBufferEnd()
    {
        bool timerEnd = TickJumpBuffer();
        return timerEnd;
    }
}