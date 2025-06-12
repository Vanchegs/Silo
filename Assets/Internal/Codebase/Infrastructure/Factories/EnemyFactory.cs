using UnityEngine;

namespace Internal.Codebase
{
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
