using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void SetHorizontal(float horiz)
    {
        animator.SetFloat("Horiz", horiz);
    }
    public void SetVertical(float vert)
    {
        animator.SetFloat("Vert", vert);
    }
    public void SetIsGrounded(bool grounded)
    {
        animator.SetBool("IsGrounded", grounded);
    }
    public void SetIsWallSliding(bool wallSliding)
    {
        animator.SetBool("IsWallSliding", wallSliding);
    }
    public void SetIsDead(bool endGame)
    {
        animator.SetBool("IsDead", endGame);
    }
    public void SetDamaged()
    {
        animator.SetTrigger("IsDamaged");
    }
    public void SetPressedAttack()
    {
        animator.SetTrigger("PressedAttack");
    }
}