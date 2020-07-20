using System;

public class Timer
{
    public float _currentTime;

    public Timer(float setTime)
    {
        _currentTime = setTime;
    }

    public bool Tick(float deltaTime)
    {
        if (_currentTime <= 0)
        {
            _currentTime = 0;
            return true;
        }
        
        _currentTime -= deltaTime;
        return false;
    }
}