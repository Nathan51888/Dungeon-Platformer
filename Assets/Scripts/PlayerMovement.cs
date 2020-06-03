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
    [Range(0, 1)]
    public float playerDampingHoriz;
    public bool facingRight;
    float playerVelocityX;

    private void Start() {
        facingRight = true;
    }
    private void Update() {
        if (!master.endingGame) {
            playerVelocityX = rb.velocity.x;
            playerVelocityX += Input.GetAxisRaw("Horizontal");
            playerVelocityX *= Mathf.Pow(1f - playerDampingHoriz, Time.deltaTime * 10f);
            rb.velocity = new Vector2(playerVelocityX, rb.velocity.y);
            if (Input.GetAxisRaw("Horizontal") < 0 && facingRight) {
                Flip();
                facingRight = false;
            } else if(Input.GetAxisRaw("Horizontal") > 0 && !facingRight) {
                Flip();
                facingRight = true;
            }
        } else rb.velocity = new Vector2(0,0);
    }
    private void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}