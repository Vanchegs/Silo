namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Enemy enemy; 
        private readonly EnemyConfig enemyConfig;

        public EnemyFactory(Enemy enemy, EnemyConfig enemyConfig)
        {
            this.enemy = enemy;
            this.enemyConfig = enemyConfig;
        }
        
        public Enemy CreateEnemy()
        {
            enemy.Initialize(enemyConfig);

            return enemy;
        }
    }
}
