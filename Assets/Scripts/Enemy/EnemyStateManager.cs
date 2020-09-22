using Enemy.States;
using UnityEngine;

namespace Enemy
{
    public class EnemyStateManager : MonoBehaviour
    {
        [SerializeField] private GameObject triggerArea;
        [SerializeField] private GameObject hotArea;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float dashTime;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float attackDistance;
        [SerializeField] private float attackCooldown;
        public bool inRange;

        public IEnemyState CurrentState { get; private set; }
        public GameObject Player { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Animator Animator { get; private set; }
        public bool IsDashing { get; set; }
        public GameObject TiggerArea => triggerArea;
        public GameObject HotArea => hotArea;
        public float MoveSpeed => moveSpeed;
        public float DashTime => dashTime;
        public float DashSpeed => dashSpeed;
        public float AttackDistance => attackDistance;
        public float AttackCooldown => attackCooldown;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<Animator>();
            Player = GameObject.FindWithTag("Player");
        }

        private void Start()
        {
            TransitionToState(IdleState);
        }

        private void Update()
        {
            CurrentState.Update(this);
        }

        public void TransitionToState(IEnemyState state)
        {
            CurrentState = state;
            CurrentState.Enter(this);
        }

        #region Enemy States

        public readonly IdleState IdleState = new IdleState();
        public readonly ChaseState ChaseState = new ChaseState();
        public readonly WanderState WanderState = new WanderState();
        public readonly DashState DashState = new DashState();

        #endregion
    }
}