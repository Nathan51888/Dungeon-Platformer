﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMaster master;
    public PlayerMovement movement;
    public Animator animator;
    public float attackPressedRememberTime;
    float attackPressedRemember;

    private void Start() {
        attackPressedRemember = attackPressedRememberTime;
    }
    public Transform attackPoint;
    public LayerMask enemyHurtBox;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    
    private void Update() {
        if (!master.endingGame) {
            if (attackPressedRemember <= 0) {
                //Able to attack now
                if (Input.GetButtonDown("Attack1")) {
                    animator.SetTrigger("PressedAttack");
                    Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPoint.position, new Vector2(attackRangeX, attackRangeY), 0,
                    enemyHurtBox);
                    for (int i = 0; i < enemiesToDamage.Length; i++) {
                        enemiesToDamage[i].GetComponent<EnemyMaster>().TakeDamage(damage, movement.isFacingRight);
                    }
                    attackPressedRemember = attackPressedRememberTime;
                }
            }else attackPressedRemember -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, new Vector3(attackRangeX, attackRangeY, 1f));
    }
}