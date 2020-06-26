using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMaster master;
    PlayerDetection pd;
    PlayerJump playerJump;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        master = GetComponent<PlayerMaster>();
        pd = GetComponent<PlayerDetection>();
        playerJump = GetComponent<PlayerJump>();
    }

    public float playerSpeed;
    public bool isFacingRight;
    public float playerAxis;
    float playerVelocityX;
    

    private void Start() {
        isFacingRight = true;
    }

    private void FixedUpdate() {
        if (!master.endingGame) {
            playerAxis = Input.GetAxisRaw("Horizontal");
            if (playerJump.wallJumpRemember < 0) {
                playerVelocityX = playerAxis * playerSpeed;
                rb.velocity = new Vector2(playerVelocityX, rb.velocity.y);
            }
            if (rb.velocity.x < 0 && isFacingRight) {
                master.Flip();
                isFacingRight = false;
            } else if(rb.velocity.x > 0 && !isFacingRight) {
                master.Flip();
                isFacingRight = true;
            }
        }
    }
}