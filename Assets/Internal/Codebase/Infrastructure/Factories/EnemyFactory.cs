using System;
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
            
            if (!enemyConfigs.TryGetValue(enemyType, out var config))
                throw new ArgumentException($"Enemy type {enemyType} not found in configs");

            return enemy;
        }
    }
}
