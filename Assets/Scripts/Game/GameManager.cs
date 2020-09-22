using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public Text timerText;
        public Vector2 lastCheckpointPos;
        public float currentTime;
        public bool isCounting;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(_instance);
            }
            else
            {
                Destroy(gameObject);
            }

            _instance.isCounting = true;
            _instance.timerText = timerText;
        }

        private void Update()
        {
            if (isCounting == false) return;

            currentTime += Time.deltaTime;
            var timeText = $"Time: {currentTime.ToString("F")}";
            _instance.timerText.text = timeText;
        }
    }
}