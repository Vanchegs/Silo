namespace Internal.Codebase
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(EnemyType enemyType);
    }
}
