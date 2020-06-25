using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartol : MonoBehaviour
{
    public EnemyMaster master;
    public Rigidbody2D rb;
    public float speedMax;
    float speed;
    public int direction;
    public float distance;
    public bool isFacingRight;
    public Transform groundDetection;

    private void Update() {
        speed = speedMax * direction;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (groundInfo.collider == false) {
            if (isFacingRight == true) {
                transform.eulerAngles = new Vector3(0,180,0);
                isFacingRight = false;
                direction = -1;
            }
            else {
                transform.eulerAngles = new Vector3(0,0,0);
                isFacingRight = true;
                direction = 1;
            }
        }
        if (master.stunRemember <= 0)
            rb.velocity = new Vector2(speed, rb.velocity.y);
    }
}
