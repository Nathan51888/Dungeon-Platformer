using UnityEngine;

public static class PlayerInput
{
    static float playerAxisX;
    static float playerAxisY;
    static bool pressedJump;
    static bool releasedJump;
    static bool pressedAttack1;
    static bool pressedReset;
    static bool pressedSubmit;
    static bool pressedCancel;
    
    public static float GetHorizontalAxis()
    {
        playerAxisX = Input.GetAxisRaw("Horizontal");
        return playerAxisX;
    }
    public static float GetVerticalAxis()
    {
        playerAxisY = Input.GetAxisRaw("Vertical");
        return playerAxisY;
    }
    public static bool GetJumpPressed()
    {
        pressedJump = Input.GetButtonDown("Jump");
        return pressedJump;
    }
    public static bool GetJumpReleased()
    {
        releasedJump = Input.GetButton("Jump");
        return releasedJump;
    }
    public static bool GetAttack1Pressed()
    {
        pressedAttack1 = Input.GetButtonDown("Attack1");
        return pressedAttack1;
    }
    public static bool GetResetPressed()
    {
        pressedReset = Input.GetButtonDown("Reset");
        return pressedReset;
    }
    public static bool GetSubmitPressed()
    {
        pressedSubmit = Input.GetButtonDown("Submit");
        return pressedSubmit;
    }
    public static bool CancelPressed()
    {
        pressedCancel = Input.GetButtonDown("Cancel");
        return pressedCancel;
    }
}