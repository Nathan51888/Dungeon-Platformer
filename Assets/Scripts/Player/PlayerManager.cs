using Game;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Player
{
    public class PlayerManager : MonoBehaviour, IDamageable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int numOfHearts;
        [SerializeField] private Image[] hearts;
        [SerializeField] private Sprite emptyHeart;
        [SerializeField] private Sprite fullHeart;
        private int _currentHealth;
        private GameManager _manager;
        private PlayerInputAction _playerInput;
        private PlayerStateManager _stateManager;

        private void Awake()
        {
            _playerInput = new PlayerInputAction();
            _stateManager = GetComponent<PlayerStateManager>();
        }

        private void Start()
        {
            _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            _playerInput.Debug.Enable();
            _playerInput.Debug.ReloadScene.performed += ReloadScene;
            transform.position = _manager.lastCheckpointPos;
            _currentHealth = maxHealth;
        }

        private void Update()
        {
            UpdateHeartUI();
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            _stateManager.TransitionToState(_stateManager.HurtState);
            if (_currentHealth <= 0)
                SceneManager.LoadScene("Game");
        }

        private void UpdateHeartUI()
        {
            if (_currentHealth > numOfHearts)
                _currentHealth = numOfHearts;

            for (var i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = i < _currentHealth ? fullHeart : emptyHeart;
                hearts[i].enabled = i < numOfHearts;
            }
        }

        private void ReloadScene(InputAction.CallbackContext callbackContext)
        {
            SceneManager.LoadScene("Game");
        }
    }
}