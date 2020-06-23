using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    PlayerMovement playerMovement;
    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public float wallJumpTimeRemember;
    public float wallSlideSpeed;
    public float wallDistance;
    public bool isWallSliding = false;
    RaycastHit2D WallCheckHit;
    public float wallJumpTime;
    public LayerMask groundLayers;
    public LayerMask wallLayers;
    public bool isGrounded;

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.4f, transform.position.y - 1f),
            new Vector2 (transform.position.x + 0.4f, transform.position.y - 1.1f), groundLayers);
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y -1f), new Vector2(0.8f, 0.1f));
    }
    private void FixedUpdate() {
        wallJumpTime -= Time.deltaTime;
        if (playerMovement.isFacingRight) {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0), wallDistance, wallLayers);
            Debug.DrawRay(transform.position, new Vector2(wallDistance, 0), Color.green);
        } else {
            WallCheckHit = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0), wallDistance, wallLayers);
            Debug.DrawRay(transform.position, new Vector2(-wallDistance, 0), Color.green);
        }

        if (WallCheckHit && !isGrounded && playerMovement.playerAxis != 0) {
            isWallSliding = true;
            wallJumpTime = wallJumpTimeRemember;
        } else
            isWallSliding = false;
    }
}
