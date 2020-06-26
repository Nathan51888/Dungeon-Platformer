using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerMaster master;
    public PlayerDetection detection;
    Animator animator;
    Rigidbody2D rigidbody;

    private void Start() {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate() {
        animator.SetFloat("Horiz", Mathf.Abs(rigidbody.velocity.x));
        animator.SetFloat("Vert", rigidbody.velocity.y);
        animator.SetBool("IsGrounded", detection.isGrounded);
        animator.SetBool("IsWallSliding", detection.isWallSliding);
        animator.SetBool("IsDead", master.endingGame);
    }
}
