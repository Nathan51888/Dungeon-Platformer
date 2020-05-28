using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    JumpDetection jd;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jd = GetComponent<JumpDetection>();
    }

    [Range (1, 10)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    float JumpPressedRememberTime = 0.1f;
    float JumpPressedRemember = 0;
    private void Update()
    {
        JumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
            JumpPressedRemember = JumpPressedRememberTime;

        if (JumpPressedRemember > 0 && jd.isGrounded)
        {
            JumpPressedRemember = 0f;
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, 1, 0, 0.5f);
        Gizmos.DrawCube (new Vector2 (transform.position.x, transform.position.y - 0.505f), new Vector2 (1, 0.01f));
    }
}