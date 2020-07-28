using System;
using UnityEngine;

public class Timer
{
    public Timer(float currentTime = 0)
    {
        RecordedTime = currentTime;
    }
    public float RecordedTime { get; set; }

    public bool IsTimerPassed(float fmaxTime)
    {
        if (fmaxTime < (Time.time - RecordedTime))
            return true;
        
        return false;
    }
}