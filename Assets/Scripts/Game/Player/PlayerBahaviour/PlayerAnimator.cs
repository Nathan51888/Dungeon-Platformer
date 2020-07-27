using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static Animator Animator;

    private void Start()
    {
        Animator = GetComponentInChildren<Animator>();
    }
    private void LateUpdate()
    {
        SetHorizontal(Mathf.Abs(PlayerInput.PlayerAxisX));
        SetVertical(PlayerPhysics.Rigidbody.velocity.y);
        SetIsGrounded(PlayerInfo.IsGrounded);
    }
    public static void SetHorizontal(float horiz)
    {
        Animator.SetFloat("Horiz", horiz);
    }
    public static void SetVertical(float vert)
    {
        Animator.SetFloat("Vert", vert);
    }
    public static void SetIsGrounded(bool grounded)
    {
        Animator.SetBool("IsGrounded", grounded);
    }
    public static void SetIsWallSliding(bool wallSliding)
    {
        Animator.SetBool("IsWallSliding", wallSliding);
    }
    public static void SetIsDead(bool endGame)
    {
        Animator.SetBool("IsDead", endGame);
    }
    public static void SetDamaged()
    {
        Animator.SetTrigger("IsDamaged");
    }
    public static void SetPressedAttack()
    {
        Animator.SetTrigger("PressedAttack");
    }
}