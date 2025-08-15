using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;

        public EnemyFactory(EnemyConfigsDictionary enemyConfigs)
        {
            this.enemyConfigs = enemyConfigs.configs;
        }

        public Enemy CreateEnemy(EnemyType enemyType)
        {
            if (!enemyConfigs.TryGetValue(enemyType, out var config))
                throw new ArgumentException($"Enemy type {enemyType} not found in configs");

            Enemy enemyInstance = GameObject.Instantiate(config.EnemyPrefab);
    
            enemyInstance.Initialize(config);
    
            return enemyInstance;
        }
    }
}
