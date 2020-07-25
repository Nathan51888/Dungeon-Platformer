using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public static Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void LateUpdate()
    {
        SetHorizontal(Mathf.Abs(PlayerInput.PlayerAxisX));
        SetVertical(PlayerPhysics._rigidbody.velocity.y);
        SetIsGrounded(PlayerDetection.isGrounded);
    }
    public static void SetHorizontal(float horiz)
    {
        animator.SetFloat("Horiz", horiz);
    }
    public static void SetVertical(float vert)
    {
        animator.SetFloat("Vert", vert);
    }
    public static void SetIsGrounded(bool grounded)
    {
        animator.SetBool("IsGrounded", grounded);
    }
    public static void SetIsWallSliding(bool wallSliding)
    {
        animator.SetBool("IsWallSliding", wallSliding);
    }
    public static void SetIsDead(bool endGame)
    {
        animator.SetBool("IsDead", endGame);
    }
    public static void SetDamaged()
    {
        animator.SetTrigger("IsDamaged");
    }
    public static void SetPressedAttack()
    {
        animator.SetTrigger("PressedAttack");
    }
}