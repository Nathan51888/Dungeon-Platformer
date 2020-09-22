using System.Collections;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingTrigger : MonoBehaviour
{
    public Text endingText;
    public GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine("OnEnding");
    }

    private IEnumerator OnEnding()
    {
        manager.isCounting = false;
        endingText.enabled = true;
        var finalTimeText = $"You Escaped In {manager.currentTime.ToString("F")} Seconds!";
        endingText.text = finalTimeText;
        yield return new WaitForSeconds(7);
        endingText.text = "Thanks For Playing";
        yield return new WaitForSeconds(4);
        manager.currentTime = 0;
        manager.lastCheckpointPos = new Vector2(25, 5);
        SceneManager.LoadScene("Game");
    }
}