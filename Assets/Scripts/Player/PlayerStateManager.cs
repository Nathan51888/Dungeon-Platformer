using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerStateManager : MonoBehaviour
    {
        #region Player States

        public readonly IdleState IdleState = new IdleState();
        public readonly RunState RunState = new RunState();
        public readonly IdleJumpState IdleJumpState = new IdleJumpState();
        public readonly RunJumpState RunJumpState = new RunJumpState();
        public readonly DashState DashState = new DashState();
        public readonly FallState FallState = new FallState();
        public readonly AttackState AttackState = new AttackState();
        public readonly HurtState HurtState = new HurtState();

        #endregion

        #region Animation

        public readonly string PLayerIdle = "Player_Idle";
        public readonly string PLayerRun = "Player_Run";
        public readonly string PLayerIdleJump = "Player_Idle_Jump";
        public readonly string PLayerRunJump = "Player_Run_Jump";
        public readonly string PLayerFall = "Player_Fall";
        public readonly string PLayerAttack = "Player_Attack";
        public readonly string PLayerDash = "Player_Dash";
        public readonly string PLayerHurt = "Player_Hurt";

        #endregion

        #region Variables

        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private LayerMask enemyHurtbox;
        [SerializeField] private GameObject attackPoint;
        [SerializeField] private ParticleSystem attackParticle;
        [SerializeField] private ParticleSystem hurtParticle;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpVelocity;
        [SerializeField] private float dashSpeed;
        [SerializeField] private float dashTime;
        [SerializeField] private float dashCooldown;
        [SerializeField] private float attackCooldown;
        [SerializeField] private float attackRangeX;
        [SerializeField] private float attackRangeY;
        private string _currentAnimation;
        public IPlayerState CurrentState { get; private set; }
        public float CurrentDashCooldown { get; set; }
        public float CurrentAttackCooldown { get; set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public Animator Animator { get; private set; }
        public bool IsGrounded { get; private set; }
        public LayerMask EnemyHurtbox => enemyHurtbox;
        public GameObject AttackPoint => attackPoint;
        public ParticleSystem AttackParticle => attackParticle;
        public ParticleSystem HurtParticle => hurtParticle;
        public float MoveSpeed => moveSpeed;
        public float JumpVelocity => jumpVelocity;
        public float DashTime => dashTime;
        public float DashSpeed => dashSpeed;
        public float DashCooldown => dashCooldown;
        public float AttackCooldown => attackCooldown;
        public float AttackRangeX => attackRangeX;
        public float AttackRangeY => attackRangeY;

        #endregion

        #region MonoBehaviour

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            CurrentDashCooldown = 0;
            CurrentAttackCooldown = 0;
            TransitionToState(IdleState);
        }

        private void Update()
        {
            if (CurrentDashCooldown > 0)
                CurrentDashCooldown -= Time.deltaTime;
            if (CurrentAttackCooldown > 0)
                CurrentAttackCooldown -= Time.deltaTime;

            GroundCheck();
            CurrentState.OnDetected(this);
            CurrentState.Update(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawCube(new Vector2(position.x, position.y - 0.7f), new Vector2(0.8f, 0.1f));
            Gizmos.DrawWireCube(AttackPoint.transform.position, new Vector3(attackRangeX, attackRangeY, 1f));
        }

        #endregion

        #region Class Method

        private void GroundCheck()
        {
            var position = transform.position;
            IsGrounded = Physics2D.OverlapBox(
                new Vector2(position.x, position.y - 0.7f),
                new Vector2(0.8f, 0.1f),
                0, groundLayers);
        }

        public void TransitionToState(IPlayerState state)
        {
            CurrentState = state;
            CurrentState.Enter(this);
        }

        public void ChangeAnimation(string nextAnimation)
        {
            // Return if animation is the same
            if (_currentAnimation == nextAnimation) return;
            Animator.Play(nextAnimation, 0);
            _currentAnimation = nextAnimation;
        }

        #endregion
    }
}