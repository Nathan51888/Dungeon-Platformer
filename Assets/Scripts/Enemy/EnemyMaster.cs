using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaster : MonoBehaviour
{
    public PlayerMovement movement;
    public HealthBar enemyHealthBar;
    public Animator animator;
    public Rigidbody2D rb;
    Transform playerPos;
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        enemyHealthBar.SetMaxHealth(enemyMaxHealth);
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public float stunRemember;
    public float stunRememberTime;
    public float agroRange;
    public int enemyHealth;
    public int enemyMaxHealth;
    public float knockBackStrength;
    public Vector2 direction;
    public Transform groundDetection;

    private void Update() {
        // Enemy is not dead
        if (enemyHealth > 0) {
            stunRemember -= Time.deltaTime;
            float distToPlayer = Vector2.Distance(transform.position, playerPos.position);
            if (distToPlayer > agroRange)
                animator.SetBool("IsInRange", false);
            else if (distToPlayer < agroRange)
                animator.SetBool("IsInRange", true);
            if (stunRemember <= 0)
                rb.velocity = new Vector2(0, rb.velocity.y);
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
