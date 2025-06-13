using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Internal.Codebase
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly SerializedDictionary<EnemyType, EnemyConfig> enemyConfigs;

        public EnemyFactory(SerializedDictionary<EnemyType, EnemyConfig> enemyConfigs)
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
