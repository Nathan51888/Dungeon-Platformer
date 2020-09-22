namespace Enemy.States
{
    public interface IEnemyState
    {
        void Enter(EnemyStateManager stateManager);
        void Update(EnemyStateManager stateManager);
    }
}