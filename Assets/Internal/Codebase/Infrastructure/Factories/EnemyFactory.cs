using System.Collections.Generic;
using Zenject;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        [Inject] private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;
        
        public Enemy CreateEnemy(EnemyType enemyType)
        {
            var enemy = enemyConfigs[enemyType].enemyPrefab;
            enemy.Initialize(enemyConfigs[enemyType]);
            
            return enemy;
        }
    }
}
