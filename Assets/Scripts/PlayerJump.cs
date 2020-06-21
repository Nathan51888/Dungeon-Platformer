using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerDetection pd;
    PlayerMaster master;
    PlayerMovement movement;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayerDetection>();
        master = GetComponent<PlayerMaster>();
        movement = GetComponent<PlayerMovement>();
    }

    public float jumpVelocity;
    public float wallJumpVelocityX;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float JumpPressedRememberTime;
    public float GroundRememberTime;
    public float wallJumpRememberTime;
    float JumpPressedRemember = 0;
    float GroundRemember = 0;
    public float wallJumpRemember = 0;

    private void Update() {
        if (!master.endingGame) {
            if (Input.GetButtonDown("Jump")) {
                Debug.Log("Player pressed jump");
                JumpPressedRemember = JumpPressedRememberTime;
            }
            if (pd.isGrounded)
                GroundRemember = GroundRememberTime;
        }else rb.velocity = new Vector2(0,0);
    }
    private void FixedUpdate() {
        //Timers
        JumpPressedRemember -= Time.deltaTime;
        GroundRemember -= Time.deltaTime;
        wallJumpRemember -= Time.deltaTime;
        //After pressed jump or left ground
        if (wallJumpRemember < 0) {
            if (JumpPressedRemember > 0 && GroundRemember > 0) {
                JumpPressedRemember = 0f;
                GroundRemember = 0f;
                Debug.Log("Player jumped");
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }
        
        //Jump gravity
        if (rb.velocity.y < 0) {
            Debug.Log("Normal jump gravity");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            Debug.Log("Low jump gravity");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }
        //Is wall sliding
        if (pd.isWallSliding) {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, pd.wallSlideSpeed, float.MaxValue));
            //Wall jump velocity
            if (movement.isFacingRight && JumpPressedRemember > 0) {
                pd.isWallSliding = false;
                JumpPressedRemember = 0f;
                Debug.Log("Player wall jumped left");
                wallJumpRemember = wallJumpRememberTime;
                rb.velocity = new Vector2(wallJumpVelocityX * -1, jumpVelocity);
            } 
            else if (!movement.isFacingRight && JumpPressedRemember > 0) {
                pd.isWallSliding = false;
                JumpPressedRemember = 0f;
                Debug.Log("Player wall jumped right");
                wallJumpRemember = wallJumpRememberTime;
                rb.velocity = new Vector2(wallJumpVelocityX * 1, jumpVelocity);
            }
        }  
    }
}