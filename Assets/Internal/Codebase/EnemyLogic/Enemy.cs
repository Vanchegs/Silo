using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        private int speed;
        private int damage;
        private bool isDead;
        private float currentHealth;
        private int maxHealth;

        internal IMovement movement;

        public virtual void Initialize(EnemyConfig enemyConfig, Transform shelterPosition)
        {
            speed = enemyConfig.Speed;
            damage = enemyConfig.Damage;
            maxHealth = enemyConfig.MaxHealth;
            
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(float damage)
        {
            if (isDead) return;
            
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                isDead = true;
                Die();
            }
        }

        public void Die() => 
            Destroy(gameObject);
    }
}
