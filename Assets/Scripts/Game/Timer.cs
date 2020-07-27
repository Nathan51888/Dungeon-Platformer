using System;
using UnityEngine;

public class Timer
{
    public Timer()
    {
        RecordedTime = Time.time;
    }
    public float RecordedTime { get; set; }

    public bool TimerIsPassed(float fmaxTime)
    {
        if (fmaxTime < (Time.time - RecordedTime))
            return true;
        
        return false;
    }
}