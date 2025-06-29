using System;
using System.Collections.Generic;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;

        public EnemyFactory(EnemyConfigsDictionary enemyConfigs) => 
            this.enemyConfigs = enemyConfigs.configs;

        public Enemy CreateEnemy(EnemyType enemyType)
        {
            var enemy = enemyConfigs[enemyType].enemyPrefab;
            
            if (!enemyConfigs.TryGetValue(enemyType, out var config))
                throw new ArgumentException($"Enemy type {enemyType} not found in configs");

            return enemy;
        }
    }
}
