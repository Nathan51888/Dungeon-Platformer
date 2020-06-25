using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public PlayerMovement movement;
    public HealthBar enemyHealthBar;
    Rigidbody2D rb;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);
    }
    public float stunRemember;
    public float stunRememberTime;
    public int enemyHealth;
    public int enemyMaxHealth;
    public float knockBackStrength;
    public Vector2 direction;

    private void FixedUpdate() {
        if (enemyHealth > 0) {
            stunRemember -= Time.deltaTime;    
        } 
        else if (enemyHealth <= 0)
            Destroy(gameObject);
    }
    public void TakeDamage(int damage, bool facingRight) {
        if (movement.isFacingRight)
            rb.AddForce(direction.normalized * knockBackStrength, ForceMode2D.Impulse);
        else if (!movement.isFacingRight)
            rb.AddForce(direction.normalized * -knockBackStrength, ForceMode2D.Impulse);
        stunRemember = stunRememberTime;
        enemyHealth -= damage;
        Debug.Log("Enemy taken damage");
        enemyHealthBar.SetHealth(enemyHealth);
    }
}
