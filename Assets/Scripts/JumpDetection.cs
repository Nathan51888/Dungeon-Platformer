using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDetection : MonoBehaviour
{
    public bool isGrounded;
    public LayerMask groundLayers;

    private void Update()
    {
        isGrounded = Physics2D.OverlapArea (new Vector2 (transform.position.x - 1f, transform.position.y - 1f),
            new Vector2 (transform.position.x + 1f, transform.position.y - 1.1f), groundLayers);
    }
}
