using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour
{
    Transform playerPos;
    public float chaseSpeed;
    public bool isFacingRight = true;

    // Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, 
        new Vector2(playerPos.position.x, animator.transform.position.y), chaseSpeed * Time.deltaTime);
        if (animator.transform.position.x > playerPos.position.x) {
            // Player is on left
            isFacingRight = false;
        }
        else if (animator.transform.position.x < playerPos.position.x) {
            // Player is on right
            isFacingRight = true;
        }
        if (isFacingRight)
            animator.transform.eulerAngles = new Vector3(0,0,0);
        else
            animator.transform.eulerAngles = new Vector3(0,180,0);
    }

    // Exit
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("IsFollowing", false);
    }
}