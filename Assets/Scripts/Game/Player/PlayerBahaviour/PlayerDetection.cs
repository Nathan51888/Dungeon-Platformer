using UnityEngine;

public class PlayerDetection : MonoBehaviour 
{
    private void Update() 
    {
        CheckGround();
    }

    [SerializeField] private LayerMask _groundLayers;

    private void CheckGround()
    {
        PlayerInfo.IsGrounded = Physics2D.OverlapArea(
            new Vector2 (transform.position.x - 0.4f, transform.position.y - 1f),
            new Vector2 (transform.position.x + 0.4f, transform.position.y - 1.1f), 
            _groundLayers);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y -1f), new Vector2(0.8f, 0.1f));
    }
}