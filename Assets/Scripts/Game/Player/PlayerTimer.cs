using UnityEngine;

public class PlayerTimer
{
    Timer jumpBufferTimer;

    public void SetJumpBufferTimer()
    {
        jumpBufferTimer = new Timer(PlayerInfo.maxJumpBufferTime);
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