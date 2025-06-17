using UnityEngine;

namespace Internal.Codebase
{
    public class Enemy : MonoBehaviour
    {
        private int speed;
        private int damage;
        private bool isDead;
        private int currentHealth;
        private int maxHealth;

        internal IMovement movement;

        public void Initialize(EnemyConfig enemyConfig)
        {
            speed = enemyConfig.speed;
            damage = enemyConfig.damage;
            maxHealth = enemyConfig.maxHealth;

            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(int damage)
        {
            if (isDead) return;

            currentHealth -= damage;
        
            Debug.Log(currentHealth);
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
