using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour, IMovement
    {
        private int speed;
        private int damage;
        private bool isDead;
        private int currentHealth;
        private int maxHealth;

        public void Initialize(EnemyConfig enemyConfig)
        {
            speed = enemyConfig.speed;
            damage = enemyConfig.damage;
            maxHealth = enemyConfig.maxHealth;

            currentHealth = maxHealth;
        }

        public virtual void Move()
        {
            
        }

        public void TakeDamage(int damage)
        {
            if (isDead) return;

            currentHealth -= damage;
        
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Die() => 
            Destroy(gameObject);
    }
}
