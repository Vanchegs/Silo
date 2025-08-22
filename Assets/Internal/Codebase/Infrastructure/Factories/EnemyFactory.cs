using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly Dictionary<EnemyType, GameObject> enemyConfigs;

        public EnemyFactory(EnemyConfigsDictionary enemyConfigs)
        {
            this.enemyConfigs = enemyConfigs.configs;
        }

        public Enemy CreateEnemy(EnemyType enemyType)
        {
            if (!enemyConfigs.TryGetValue(enemyType, out var prefab))
                throw new ArgumentException($"Enemy type {enemyType} not found in configs");

            var enemyPrefab = Object.Instantiate(prefab);
            var enemy = enemyPrefab.GetComponent<Enemy>();
            
            enemy.Initialize();

            return enemy;
        }
    }
}
