using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour
{
    public float speedMax;
    float speed;
    public int direction;
    public float distance;
    public bool isFacingRight;
    Transform groundDetection;
    Rigidbody2D rb;
    float stunRemember;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (groundDetection == null) {
            groundDetection = animator.gameObject.GetComponent<EnemyMaster>().groundDetection;
        }
        if (rb == null) {
            rb = animator.gameObject.GetComponent<EnemyMaster>().rb;
        }
        if (stunRemember == null) {
            stunRemember = animator.gameObject.GetComponent<EnemyMaster>().stunRemember;
        }
        if (direction > 0) {
            isFacingRight = true;
            animator.transform.eulerAngles = new Vector3(0,0,0);
        }
        else {
            isFacingRight = false;
            animator.transform.eulerAngles = new Vector3(0,180,0);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        speed = speedMax * direction;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false) {
            animator.SetBool("IsPatroling", false);
            if (isFacingRight == true) {
                animator.transform.eulerAngles = new Vector3(0,180,0);
                isFacingRight = false;
                direction = -1;
            }
            else {
                animator.transform.eulerAngles = new Vector3(0,0,0);
                isFacingRight = true;
                direction = 1;
            }
        }
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("IsPatroling", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
