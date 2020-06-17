using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    float stunRemember;
    public float stunRememberTime;
    public int enemyHealth;
    public float speedHoriz;
    public int moveDirection;
    public float knockBackStrength;
    public Vector2 direction;

    private void FixedUpdate() {
        if (enemyHealth > 0) {
            if (stunRemember <= 0) {
                moveDirection = -1;
                rb.velocity = new Vector2(speedHoriz * moveDirection, rb.velocity.y);
            }
            else
                moveDirection = 0;
            
            stunRemember -= Time.deltaTime;    
        } 
        else if (enemyHealth <= 0)
            Destroy(gameObject);
    }
    public void TakeDamage(int damage) {
        rb.AddForce(direction.normalized * knockBackStrength, ForceMode2D.Impulse);
        stunRemember = stunRememberTime;
        enemyHealth -= damage;
        Debug.Log("Enemy taken damage");
    }
}
