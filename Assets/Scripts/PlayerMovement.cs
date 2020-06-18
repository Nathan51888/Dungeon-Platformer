using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerMaster master;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        master = GetComponent<PlayerMaster>();
    }

    public float playerSpeed;
    public bool isFacingRight;
    public float playerAxis;
    float playerVelocityX;

    private void Start() {
        isFacingRight = true;
    }

    private void FixedUpdate() {
        playerAxis = Input.GetAxisRaw("Horizontal");
        playerVelocityX = playerAxis * playerSpeed;
        rb.velocity = new Vector2(playerVelocityX, rb.velocity.y);
        if (playerAxis < 0 && isFacingRight) {
            Flip();
            isFacingRight = false;
        } else if(playerAxis > 0 && !isFacingRight) {
            Flip();
            isFacingRight = true;
        }
    }
    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}