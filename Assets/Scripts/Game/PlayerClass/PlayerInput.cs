using UnityEngine;

public static class PlayerInput
{
    public static float PlayerAxisX
    {
        get
        {
            float axisX = Input.GetAxisRaw("Horizontal");
            return axisX;
        }
    }
    public static float PlayerAxisY
    {
        get
        {
            float axisY = Input.GetAxisRaw("Vertical");
            return axisY;
        }
    }
    public static bool PressedJump
    {
        get
        {
            bool pressedJump = Input.GetButtonDown("Jump");
            return pressedJump;
        }
    }
    public static bool ReleasedJump
    {
        get
        {
            bool releasedJump = !Input.GetButton("Jump");
            return releasedJump;
        }
    }
    public static bool PressedAttack1
    {
        get
        {
            bool pressedAttack1 = Input.GetButtonDown("Attack1");
            return pressedAttack1;
        }
    }
}