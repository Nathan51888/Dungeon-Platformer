using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetection : MonoBehaviour
{
    public bool isGrounded;
    public LayerMask groundLayers;

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.5f, transform.position.y - 0.5f),
            new Vector2 (transform.position.x + 0.5f, transform.position.y - 0.51f), groundLayers);
    }
}
