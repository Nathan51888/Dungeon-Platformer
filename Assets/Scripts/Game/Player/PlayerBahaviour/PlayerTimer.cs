using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    private Timer _attackTimer = new Timer ();
    private Timer _jumpTimer = new Timer ();
    public static bool CanAttack;
    public static bool CanJump;

    private void StartAttackTimer ()
    {
        _attackTimer = new Timer (Time.time);
    }
    private void StartJumpTimer ()
    {
        _jumpTimer = new Timer (Time.time);
    }
    private bool CheckAttackTimer (float maxTime)
    {
        if (_attackTimer.IsTimerPassed (maxTime))
            return true;
        if (PlayerInput.PressedAttack1 && CanAttack)
        {
            StartAttackTimer ();
            return false;
        }
        return false;
    }
    private bool CheckJumpTimer (float maxTime)
    {
        if (PlayerInput.PressedJump)
        {
            StartJumpTimer ();
            return true;
        }
        if (_jumpTimer.IsTimerPassed (maxTime))
            return false;
        return true;
    }
    private void Update ()
    {
        CanAttack = CheckAttackTimer (PlayerInfo.MaxAttackBufferTime);
        CanJump = CheckJumpTimer (PlayerInfo.MaxJumpBufferTime);
    }
}