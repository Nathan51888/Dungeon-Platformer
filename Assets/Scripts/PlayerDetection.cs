using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public float wallJumpTime = 0.2f;
    public float wallSlideSpeed = 0.15f;
    public float wallDistance = 0.6f;
    public bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    float jumpTime;
    public LayerMask groundLayers;
    public LayerMask wallLayers;
    public bool isGrounded;

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.9f, transform.position.y - 1f),
            new Vector2 (transform.position.x + 0.9f, transform.position.y - 1.1f), groundLayers);
    }
    private void FixedUpdate() {
        if (playerMovement.isFacingRight) {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayers);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.green);
        } else {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, wallLayers);
            Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.green);
        }

        if (WallCheckHit && !isGrounded && playerMovement.playerAxis != 0) {
            isWallSliding = true;
            jumpTime = Time.time + wallJumpTime;
        } else if (jumpTime < Time.time)
            isWallSliding = false;
    }
}
