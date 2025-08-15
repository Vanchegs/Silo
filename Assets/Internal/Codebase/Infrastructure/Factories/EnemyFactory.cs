using System;
using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, EnemyConfig> enemyConfigs;
        
        private Transform shelterPosition;

        public EnemyFactory(EnemyConfigsDictionary enemyConfigs, Transform shelterPosition)
        {
            this.shelterPosition = shelterPosition;
            this.enemyConfigs = enemyConfigs.configs;
        }

        public Enemy CreateEnemy(EnemyType enemyType)
        {
            if (!enemyConfigs.TryGetValue(enemyType, out var config))
                throw new ArgumentException($"Enemy type {enemyType} not found in configs");

            var enemy = enemyConfigs[enemyType].EnemyPrefab;
            enemy.Initialize(enemyConfigs[enemyType], shelterPosition);
            
            return enemy;
        }
    }
}
