using System.Collections.Generic;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;

        public EnemyFactory(Dictionary<EnemyType, EnemyConfig> enemyConfigs)
        {
            this.enemyConfigs = enemyConfigs;
        }
        
        public Enemy CreateEnemy(EnemyType enemyType)
        {
            var enemy = enemyConfigs[enemyType].enemyPrefab;
            enemy.Initialize(enemyConfigs[enemyType]);
            
            return enemy;
        }
    }
}
