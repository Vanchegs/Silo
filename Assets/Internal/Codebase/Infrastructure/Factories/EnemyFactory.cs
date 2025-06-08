using System;
using UnityEngine;

namespace Internal.Codebase
{
    [Serializable]
    public class EnemyFactory : MonoBehaviour, IEnemyFactory
    {
        [SerializeField] private Enemy enemy; 
        [SerializeField] private EnemyConfig enemyConfig;
        
        public Enemy CreateEnemy()
        {
            enemy.Initialize(enemyConfig);
            
            
            Instantiate(enemy);

            return enemy;
        }
    }
}
