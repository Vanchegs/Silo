using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        private int speed;
        private int damage;

        public void Initialize(EnemyConfig enemyConfig)
        {
            speed = enemyConfig.speed;
            damage = enemyConfig.damage;
        }
    }
}
