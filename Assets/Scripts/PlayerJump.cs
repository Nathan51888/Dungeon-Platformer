using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerDetection pd;
    PlayerMaster master;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayerDetection>();
        master = GetComponent<PlayerMaster>();
    }

    [Range (1, 10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float JumpPressedRememberTime = 0.1f;
    public float GroundRememberTime = 0.2f;
    float JumpPressedRemember = 0;
    float GroundRemember = 0;

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
        JumpPressedRemember -= Time.deltaTime;
        GroundRemember -= Time.deltaTime;

        if (JumpPressedRemember > 0 && GroundRemember > 0 || JumpPressedRemember > 0 && pd.isWallSliding) {
            JumpPressedRemember = 0f;
            GroundRemember = 0f;
            Debug.Log("Player jumped");
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
        if (rb.velocity.y < 0) {
            Debug.Log("Normal jump gravity");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            Debug.Log("Low jump gravity");
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        if (pd.isWallSliding)
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, pd.wallSlideSpeed, float.MaxValue));
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y -1f), new Vector2(0.9f, 0.1f));
    }
}