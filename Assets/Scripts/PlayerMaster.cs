using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMaster : MonoBehaviour
{
    public Text gameEndingText;
    public Text playerHealthText;
    private void Start() {
        gameEndingText.enabled = false;
        playerHealthText.text = "Health: " + hp;
    }

    public int hp = 1;
    public int maxhp = 1;
    public int hpBuffer = 100;
    int hpBufferCurrent = 200;
    public bool endingGame = false;
    public int endGameTime = 100;

    private void FixedUpdate() {
        if (!endingGame) {
            if (hpBufferCurrent < hpBuffer) 
                hpBufferCurrent++;
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
        if (hpBufferCurrent >= hpBuffer) {
            hp -= hurt;
            playerHealthText.text = "Health: " + hp;
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
}