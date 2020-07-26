using UnityEngine;

public class PlayerDetection : MonoBehaviour 
{   
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyHurtBox;
    [SerializeField] private float _attackRangeX;
    [SerializeField] private float _attackRangeY;

    private void Update() 
    {
        CheckGround();
        CheckAttackInRange();
    }
    private void OnDrawGizmos() {
        // Ground Check
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y -1f), new Vector2(0.8f, 0.1f));
        //Attack Range
        Gizmos.DrawWireCube(_attackPoint.position, new Vector3(_attackRangeX, _attackRangeY, 1f));
    }
    
    private void CheckGround()
    {
        PlayerInfo.IsGrounded = Physics2D.OverlapArea(
            new Vector2 (transform.position.x - 0.4f, transform.position.y - 1f),
            new Vector2 (transform.position.x + 0.4f, transform.position.y - 1.1f), 
            _groundLayers);
    }
    private void CheckAttackInRange()
    {
        if (PlayerInput.GetAttack1Pressed()) {
            Collider2D[] detectedEnemies = Physics2D.OverlapBoxAll(
                _attackPoint.position, 
                new Vector2(_attackRangeX, _attackRangeY), 0,
                _enemyHurtBox);
                
            foreach (Collider2D enemiesToDamage in detectedEnemies)
            {
                /*enemiesToDamage.GetComponent<EnemyMaster>().
                TakeDamage(
                    PlayerInfo.AttackDamage, 
                    movement.isFacingRight);*/
                Debug.Log(enemiesToDamage.name);
            }
        }
    }
}