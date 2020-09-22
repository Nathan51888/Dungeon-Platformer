using UnityEngine;

namespace Game
{
    public class CheckPoint : MonoBehaviour
    {
        private GameManager _manager;

        private void Start()
        {
            _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) _manager.lastCheckpointPos = transform.position;
        }
    }
}