using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMaster : MonoBehaviour
{
    public Text gameEndingText;
    public HealthBar playerHealthBar;
    public PlayerMovement movement;
    public Animator animator;
    private void Start() {
        gameEndingText.enabled = false;
        playerHealthBar.SetMaxHealth(maxhp);
    }

    public int hp = 1;
    public int maxhp = 1;
    public int hpBufferTime = 100;
    int hpBufferCurrent;
    public bool endingGame = false;
    public int endGameTime = 100;
 
    private void FixedUpdate() {
        if (!endingGame) {
            if (hpBufferCurrent < hpBufferTime) { 
                hpBufferCurrent++;
            }
            if (Input.GetAxisRaw("Reset") > 0) {
                ResetGame();
            }
        }else {
            endGameTime--;
            if (endGameTime <= 0)
                ResetGame();
        }
    }
    public void HurtPlayer(int hurt) {
        if (hpBufferCurrent >= hpBufferTime) {
            animator.SetTrigger("IsDamaged");
            hp -= hurt;
            playerHealthBar.SetHealth(hp);
            if (hp <= 0){
                GameOver();
            }
            hpBufferCurrent = 0;
        }
    }
    private void GameOver() {
        endingGame = true;
        gameEndingText.enabled = true;
    }
    private void ResetGame() {
        SceneManager.LoadScene(0);
    }
    public void Flip() {
        movement.isFacingRight = !movement.isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}